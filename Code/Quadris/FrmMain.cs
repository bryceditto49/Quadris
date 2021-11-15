using Quadris.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Quadris {
  public partial class FrmMain : Form {
    private const int BOARD_COLS = 10;
    private const int BOARD_ROWS = 20;

    private const int CELL_WIDTH = 20;
    private const int CELL_HEIGHT = 20;

    private Label[,] gridControls;
    private Board board;

        // Jacoby added variables, 
        Piece Held_Piece = Piece.MakePiece(PieceType.L);
        bool Pause = false;
        bool filled = false;
        bool sound2 = false;
        bool sound3 = false;

        private SoundPlayer sndPlayer;

    private static readonly Dictionary<PieceColor, Image> pieceColorToImgMap = new Dictionary<PieceColor, Image> {
      {PieceColor.BLUE, Resources.cell_blue},
      {PieceColor.CYAN, Resources.cell_cyan},
      {PieceColor.GREEN, Resources.cell_green},
      {PieceColor.MAGENTA, Resources.cell_magenta},
      {PieceColor.ORANGE, Resources.cell_orange},
      {PieceColor.PURPLE, Resources.cell_purple},
      {PieceColor.RED, Resources.cell_red},
      {PieceColor.WHITE, Resources.cell_white},
      {PieceColor.YELLOW, Resources.cell_yellow},
      {PieceColor.FIRE, Resources.cell_fire},
      {PieceColor.ICE, Resources.cell_ice},
      {PieceColor.GROUND, Resources.cell_ground},
      {PieceColor.DARK, Resources.cell_dark},
    };
        // Dictionary for piece shape images
        private static readonly Dictionary<PieceColor, Image> pieceColorToImgShape = new Dictionary<PieceColor, Image> {
      {PieceColor.BLUE, Resources.cell_blue_shape},
      {PieceColor.CYAN, Resources.cell_cyan_shape},
      {PieceColor.GREEN, Resources.cell_green_shape},
      {PieceColor.MAGENTA, Resources.cell_magenta_shape},
      {PieceColor.ORANGE, Resources.cell_orange_shape},
      {PieceColor.PURPLE, Resources.cell_purple_shape},
      {PieceColor.RED, Resources.cell_red_shape},
      {PieceColor.WHITE, Resources.cell_white_shape},
      {PieceColor.YELLOW, Resources.cell_yellow_shape},
      {PieceColor.FIRE, Resources.cell_fire_shape},
      {PieceColor.ICE, Resources.cell_ice_shape},
      {PieceColor.GROUND, Resources.cell_ground_shape},
      {PieceColor.DARK, Resources.cell_dark_shape},
    };

        public FrmMain() {
      InitializeComponent();
    }

    private void FrmMain_Load(object sender, EventArgs e) {
      board = new Board();


        board = new Board();
        Piece curr_piece = Piece.GetFromSevenPieceBag();
        Piece next_piece = Piece.GetFromSevenPieceBag();
        board.Pieces.Add(curr_piece);
        board.Pieces.Add(next_piece);
        board.ActivePiece = curr_piece;
        CreateGrid();
            // Design create panel 2 and panel 3 for next and held piece 
        panel2.BackgroundImage = pieceColorToImgShape[next_piece.Color];
        panel3.BackgroundImage = null;
        sndPlayer = new SoundPlayer(Resources.lofi_music);
        sndPlayer.PlayLooping();
        sound2 = true;
        sound3 = true;
        }

    private void CreateGrid() {
      panBoard.Width = CELL_WIDTH * BOARD_COLS + 4;
      panBoard.Height = CELL_HEIGHT * BOARD_ROWS + 4;
      gridControls = new Label[BOARD_ROWS, BOARD_COLS];
      panBoard.Controls.Clear();
      for (int col = 0; col < BOARD_COLS; col++) {
        for (int row = 0; row < BOARD_ROWS; row++) {
          Label lblCell = MakeGridCell(row, col);
          panBoard.Controls.Add(lblCell);
          gridControls[row, col] = lblCell;
        }
      }
    }

    private void UpdateGrid() {
            UpdateGame();
            for (int col = 0; col < BOARD_COLS; col++) {
        for (int row = 0; row < BOARD_ROWS; row++) {
          GridCellInfo cellInfo = board.Grid[row + 4, col];
          if (cellInfo.State == CellState.OCCUPIED_ACTIVE_PIECE || cellInfo.State == CellState.OCCUPIED_PREVIOUSLY) {
            gridControls[row, col].Image = pieceColorToImgMap[cellInfo.Color];
          }
          else {
            gridControls[row, col].Image = null;
          }
        }
      }
    }

    private Label MakeGridCell(int row, int col) {
      return new Label() {
        Text = "",
        Width = CELL_WIDTH,
        Height = CELL_HEIGHT,
        FlatStyle = FlatStyle.Flat,
        Top = row * CELL_HEIGHT,
        Left = col * CELL_WIDTH
      };
    }

        private void tmrFps_Tick(object sender, EventArgs e)
        {
            // if a piece reaches the top of the board (row 3), the game losses and pieces can't be moved.
            if (!board.Game_Lost && board.moveable)
            {
                board.Update();
                UpdateGrid();
            }
            else if (!board.Game_Lost && !board.moveable)
            {

            }
            else
            {
                Paused.Visible = true;
                Paused.Text = "GAME LOST!!!";
                board.moveable = false;
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.X:
          board.RotateActivePieceRight();
          break;
        case Keys.Z:
          board.RotateActivePieceLeft();
          break;
        case Keys.Right:
          board.MoveActivePieceRight();
          break;
        case Keys.Left:
          board.MoveActivePieceLeft();
          break;
                // (Jacoby Johnson) Score 21: Q7 - Up key holds the current piece or swaps the current piece with the held piece.  
                // ------ Added variables -----
                // bool board.hold_lock (In board class): Locks the Up key when a recent swap is made and until a piece is settled 
                // bool filled: Checks to see if the held box is filled with a piece.
                // panel3: a box that displays the held piece
                // pieceColorToImgShape[Piece.Color] - Dictionary to add image shape files to be used in next and hold box.
                // Piece Held_Piece - a Piece object for the held piece

                // -----Adjusted Methods ------
                // board.SettlePiece()
                // enum MoveDir - added UP
         case Keys.Up:
               if (!Pause)
                    {
                        if (!board.hold_lock)
                        {
                            if (!filled)
                            {
                                Held_Piece = board.Pieces[0];
                                panel3.BackgroundImage = pieceColorToImgShape[Held_Piece.Color];
                                board.Pieces[1].GridRow = 0;
                                board.Pieces[1].GridCol = 3;
                                board.ActivePiece = board.Pieces[1];
                                board.Pieces[0] = board.ActivePiece;
                                board.Pieces[1] = Piece.GetFromSevenPieceBag();
                                panel2.BackgroundImage = pieceColorToImgShape[board.Pieces[1].Color];
                                filled = true;
                            }
                            // Swap occuring between current and held piece
                            else
                            {
                                Piece Curr_Piece = board.Pieces[0];
                                Held_Piece.GridRow = 0;
                                Held_Piece.GridCol = 3;
                                board.ActivePiece = Held_Piece;
                                Held_Piece = Curr_Piece;
                                panel3.BackgroundImage = pieceColorToImgShape[Curr_Piece.Color];


                            }
                            // Allows for a piece to be swapped again once the recently swapped piece is settled.
                            board.hold_lock = true;
                        }


                    }
                    break;
                case Keys.P:
                    if (Pause)
                    {
                        Paused.Text = "3";
                        Paused.Update();
                        System.Threading.Thread.Sleep(1000);
                        Paused.Text = "2";
                        Paused.Update();
                        System.Threading.Thread.Sleep(1000);
                        Paused.Text = "1";
                        Paused.Update();
                        System.Threading.Thread.Sleep(1000);
                    }
                    Pause = !Pause;
                    board.moveable = !board.moveable;
                    Paused.Visible = !Paused.Visible;
                    Paused.Text = "Paused";

                    break;
                case Keys.Down:
                    //board.Score++;
          tmrFps.Interval = 100;
          break;
        case Keys.Space:
          while(board.ActivePieceCanMove(MoveDir.DOWN))
            {
              board.Update();
            }
            UpdateGrid();
            board.SettlePiece();
            board.CheckForLine();
          break;
      } 
    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void UpdateGame()
        {
            // (Jacoby Johnson) Score 3: Q30 As a player, I would like to have my active score displayed so I can keep track of my score while playing the game.
            label2.Text = board.Score.ToString();
            panel2.BackgroundImage = pieceColorToImgShape[board.Pieces[1].Color];
            // Changes the music to more engaging music if the score is greater than 2.
            if (board.Score > 5 && sound2 == true)
            {
                sndPlayer = new SoundPlayer(Resources.bg_music_2);
                sndPlayer.PlayLooping();
                sound2 = false;
            }
            else if (board.Score > 10 && sound3 == true)
            {
                sndPlayer = new SoundPlayer(Resources.bg_music_3);
                sndPlayer.PlayLooping();
                sound3 = false;

            }
            //(Jacoby Johnson) Score 3: Q9 - Shows the next piece in the top left box

            if (board.Piece_settled)
            {
                panel2.BackgroundImage = pieceColorToImgShape[board.Pieces[1].Color];
                board.Piece_settled = false;
            }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    tmrFps.Interval = 500;
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
