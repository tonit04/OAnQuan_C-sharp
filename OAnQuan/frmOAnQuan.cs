using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAnQuan
{
    public partial class frmOAnQuan : Form
    {

        int[] board = new int[12];
        int player1Score = 0;
        int player2Score = 0;
        bool isPlayer1Turn = true;
        private Button[] boardButtons;
        private int delayTime = 700;

        public frmOAnQuan()
        {
            InitializeComponent();
            InitializeBoard();
        }
        //Hàm cập nhật giao diện 
        private void UpdateBoardUI()
        {
            boardButtons[0].Text = board[0].ToString();
            boardButtons[1].Text = board[1].ToString();
            boardButtons[2].Text = board[2].ToString();
            boardButtons[3].Text = board[3].ToString();
            boardButtons[4].Text = board[4].ToString();
            boardButtons[5].Text = board[5].ToString(); // Ô quan
            boardButtons[6].Text = board[6].ToString();
            boardButtons[7].Text = board[7].ToString();
            boardButtons[8].Text = board[8].ToString();
            boardButtons[9].Text = board[9].ToString();
            boardButtons[10].Text = board[10].ToString();
            boardButtons[11].Text = board[11].ToString(); // Ô quan
            txtPlayer1Score.Text = "" + player1Score;
            txtPlayer2Score.Text = "" + player2Score;
            txtPlayer1Score.Enabled = false;
            txtPlayer2Score.Enabled = false;

        }
        //Hàm khởi tạo chỉ số  cho nút 
        private void InitializeTag()
        {
            boardButtons[0].Tag = 0;
            boardButtons[1].Tag = 1;
            boardButtons[2].Tag = 2;
            boardButtons[3].Tag = 3;
            boardButtons[4].Tag = 4;
            boardButtons[5].Tag = 5;
            boardButtons[6].Tag = 6;
            boardButtons[7].Tag = 7;
            boardButtons[8].Tag = 8;
            boardButtons[9].Tag = 9;
            boardButtons[10].Tag = 10;
            boardButtons[11].Tag = 11;
        }
        //Hàm cập nhật lượt chơi 
        private void UpdateTurnLabel()
        {
            lblTurn.Text = isPlayer1Turn ? "Người chơi 1" : "Người chơi 2";
        }
        //Hàm cập nhật trạng thái nút thuộc về  người chơi
        private void UpdateButtonStates()
        {
            for (int i = 0; i < 12; i++)
            {
                Button btn = this.Controls.Find($"btn{i}", true).FirstOrDefault() as Button;
                if (btn != null)
                {
                    if ((isPlayer1Turn && (i >= 0 && i <= 4)) || (!isPlayer1Turn && (i >= 6 && i <= 10)))
                    {
                        btn.Enabled = true;
                        btn.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btn.Enabled = false;
                        btn.BackColor = Color.LightGray;
                    }
                }
            }
        }
        //Hàm khởi tạo bàn cờ Ô ăn quan
        private void InitializeBoard()
        {
            for (int i = 0; i < 12; i++)
            {
                board[i] = (i == 5 || i == 11) ? 10 : 5; 
            }
            
            boardButtons = new Button[] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11 };
            
            UpdateBoardUI();
            InitializeTag();
            UpdateTurnLabel();
            UpdateButtonStates(); 
        }
       //Hàm kiểm tra trò chơi kết thúc hay chưa
        private bool CheckGameOver(int[] board, ref int player1Score, ref int player2Score)
        {
            if (board[5] == 0 && board[11] == 0)
            {
                int player1RemainingPoints = 0;
                int player2RemainingPoints = 0;

                for (int i = 0; i < 5; i++)
                {
                    player1RemainingPoints += board[i];
                    board[i] = 0; 
                }

                for (int i = 6; i < 11; i++)
                {
                    player2RemainingPoints += board[i];
                    board[i] = 0; 
                }

                player1Score += player1RemainingPoints;
                player2Score += player2RemainingPoints;

                UpdateBoardUI();
                UpdateTurnLabel();

                return true; 
            }

            return false; 

        }
        //Hàm kiểm tra ai là người thắng 
        private int CheckWinner(int player1Score, int player2Score)
        {
            return player1Score == player2Score ? 0 : (player1Score > player2Score ? 1 : -1);
        }
        //Biến lưu trạng thái di chuyển 
        private bool isMoveInProgress = false; 
        private async void Button_Click(object sender, EventArgs e)
        {
            if (isMoveInProgress) return; 
            isMoveInProgress = true; 

            Button btn = sender as Button;
            int chosenIndex = int.Parse(btn.Tag.ToString());

            // Kiểm tra số lượng trên bàn cờ quân trước khi tiếp tục
            CheckAndRedistribute();

            if (board[chosenIndex] == 0)
            {
                MessageBox.Show("Ô dân này không có dân.Vui lòng chọn ô dân khác !");
                isMoveInProgress = false; 
                return;
            }
            else
            {
                using (frmChonHuongDi directionForm = new frmChonHuongDi())
                {
                    if (directionForm.ShowDialog() == DialogResult.OK)
                    {
                        if (directionForm.SelectedDirection == "Left")
                        {
                            await MoveLeft(chosenIndex); 
                        }
                        else
                        {
                            await MoveRight(chosenIndex);
                        }

                        UpdateBoardUI();

                        if (CheckGameOver(board, ref player1Score, ref player2Score))
                        {
                            int result = CheckWinner(player1Score, player2Score);
                            if (result == 0) MessageBox.Show("Kết thúc trò chơi: 2 người chơi hòa nhau " + " với số điểm " + player1Score);
                            else if (result == 1) MessageBox.Show("Kết thúc trò chơi: Người thắng là: Người chơi 1 với số điểm: " + player1Score );
                            else if (result == -1) MessageBox.Show("Kết thúc trò chơi: Người thắng là: Người chơi  2 với số điểm: " + player2Score );
                        }
                        else
                        {
                            isPlayer1Turn = !isPlayer1Turn;
                            UpdateTurnLabel();
                            UpdateButtonStates();
                        }


                    }
                }
            }
            isMoveInProgress = false; 
        }
        //Hàm thay đổi màu của nút 
        private void HighlightCell(int index, Color color)
        {
            if (index >= 0 && index < boardButtons.Length)
            {
                boardButtons[index].BackColor = color;
            }
        }
        // Biến lưu số lượng quân đang rải 
        private int currentPickCount = 0;
        //Hàm cập nhật số quân đang di chuyển
        private void UpdatePickCountUI()
        {
            lblPickCount.Text = $"{currentPickCount}";
        }
        // Hàm xử lý di chuyển sang phải
        private async Task MoveRight(int startIndex)
        {
            int count = board[startIndex];
            board[startIndex] = 0; 
            int currentIndex = startIndex;

            currentPickCount = count;
            UpdatePickCountUI();
            while (count > 0)
            {
                currentIndex = (currentIndex + 1) % 12;
                HighlightCell(currentIndex, Color.Yellow);
                UpdateBoardUI();
                board[currentIndex]++; 
                await Task.Delay(delayTime); 
                HighlightCell(currentIndex, Color.White); 
                UpdateBoardUI(); 
                count--;
                currentPickCount = count; 
                UpdatePickCountUI(); 
            }
            
            if (board[(currentIndex + 1) % 12] > 0 && ((currentIndex + 1) % 12) != 5 && ((currentIndex + 1) % 12) != 11)
            {
                await MoveRight((currentIndex + 1) % 12);
            }            
            else
            {
                await CalculateScore1(currentIndex);
            }
            UpdateBoardUI();
        }
        // Hàm xử lý di chuyển sang trái 
        private async Task MoveLeft(int startIndex)
        {
            int count = board[startIndex];
            board[startIndex] = 0;
            int currentIndex = startIndex;

            currentPickCount = count;
            UpdatePickCountUI();
            while (count > 0)
            {
                currentIndex = (currentIndex - 1 + 12) % 12;
                HighlightCell(currentIndex, Color.Yellow);
                UpdateBoardUI();
                board[currentIndex]++;
                await Task.Delay(delayTime);
                HighlightCell(currentIndex, Color.White);
                UpdateBoardUI();
                count--;
                currentPickCount = count;
                UpdatePickCountUI();
            }

            if (board[(currentIndex - 1 + 12) % 12] > 0 && ((currentIndex - 1 + 12) % 12) != 5 && ((currentIndex - 1 + 12) % 12) != 11)
            {
                await MoveLeft((currentIndex - 1 + 12) % 12);
            }
            else
            {
                await CalculateScore2(currentIndex);
            }
            UpdateBoardUI();

        }
        // Hàm tính điểm cho người chơi khi di chuyển sang phải
        private async Task CalculateScore1(int currentIndex)
        {
            int nextIndex = (currentIndex + 1) % 12;
            int tempIndex = (nextIndex + 1) % 12;
            if (board[nextIndex] == 0 && board[tempIndex] != 0)
            {
                if (isPlayer1Turn)
                    player1Score += board[tempIndex];
                else
                    player2Score += board[tempIndex];
                await Task.Delay(delayTime);
                board[tempIndex] = 0;   
                await CalculateScore1(tempIndex);
            }
        }
        // Hàm tính điểm cho người chơi khi di chuyển sang trái
        private async Task CalculateScore2(int currentIndex)
        {
            int nextIndex = (currentIndex - 1 + 12) % 12;
            int tempIndex = (nextIndex - 1 + 12) % 12;
            if (board[nextIndex] == 0 && board[tempIndex] != 0)
            {
                if (isPlayer1Turn)
                    player1Score += board[tempIndex];
                else
                    player2Score += board[tempIndex];
                await Task.Delay(delayTime);
                board[tempIndex] = 0;   
                await CalculateScore2(tempIndex);
            }
        }
        // Thêm phương thức kiểm tra và rải quân lại nếu tất cả 5 ô dân trống
        private void CheckAndRedistribute()
        {
            bool needRedistribute = true;
            int startIndex = isPlayer1Turn ? 0 : 6; 
            int endIndex = isPlayer1Turn ? 4 : 10;  

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (board[i] > 0)
                {
                    needRedistribute = false;
                    break;
                }
            }
            // Nếu cần rải quân lại
            if (needRedistribute)
            {
                int scorePenalty = 5;
                if (isPlayer1Turn)
                {
                    player1Score -= scorePenalty;
                }
                else
                {
                    player2Score -= scorePenalty;
                }
                for (int i = startIndex; i <= endIndex; i++)
                {
                    board[i] = 1;
                }
                UpdateBoardUI(); 
                MessageBox.Show("Đã rải lại quân cho các ô của bạn . Bạn bị trừ 5 điểm .");
            }
        }

        private void btnChoiLai_Click(object sender, EventArgs e)
        {
            frmOAnQuan frmOAnQuan = new frmOAnQuan();
            frmOAnQuan.Show();
            this.Close();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            frmTrangChu frmTrang = new frmTrangChu();
            frmTrang.Show();
            this.Close();
        }
    }
}
