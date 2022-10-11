﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _111_1HW2
{
    public partial class Bomb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            char[,] ia_Map = new char[10, 10];
            int[] ia_MIndex = new int[10] { 0, 7, 13, 28, 44, 62, 74, 75, 87, 90 };


            for (int i_Row = 0; i_Row < ia_Map.GetLength(0); i_Row++) {
                for (int i_Col = 0; i_Col < ia_Map.GetLength(1); i_Col++) {
                    ia_Map[i_Row, i_Col] = '0';
                }
            }
            //放上炸彈
            for (int i_Ind = 0; i_Ind < ia_MIndex.Length; i_Ind++) {
                int i_Row = (ia_MIndex[i_Ind] / ia_Map.GetLength(1));
                int i_Row = ia_MIndex[i_Ind] % (ia_Map.GetLength(1));
                ia_Map[i_Row, i_Col] = '*';
            }
            //處裡周邊數字
            for (int i_Ind = 0; i_Ind < ia_MIndex.Length; i_Ind++) {
                int i_Row = (ia_MIndex[i_Ind] / ia_Map.GetLength(1));
                int i_Row = ia_MIndex[i_Ind] % (ia_Map.GetLength(1));
                mt_CalBombValue(ref ia_Map, i_Row, i_Col, ia_Map.GetLength(0), ia_Map.GetLength(1));
            }
            for (int i_Ind = 0; i_Ind < ia_MIndex.Length; i_Ind++)
            {
                int i_Row = (ia_MIndex[i_Ind] / ia_Map.GetLength(1));
                int i_Row = ia_MIndex[i_Ind] % (ia_Map.GetLength(1));
                Response.Write(ia_Map[i_Row, i_Col]) = '*';
            }
        }
            

        void mt_CalBombValue(ref char[,] ia_Map, int i_Row, int i_Col, int i_MaxR, int i_MaxC) {
            bool b_IsBomb = mt_IsBomb(ref ia_Map, i_Row - 1, i_Col - 1, i_MaxR, int i_MaxC,);
            if (b_IsBomb == false) 
                mt_Addone(ref ia_Map, i_Row -1, i_Col -1);

            b_IsBomb = mt_IsBomb(ref ia_Map, i_Row - 1, i_Col, i_MaxR, int i_MaxC);
            if (b_IsBomb == false)
                mt_Addone(ref ia_Map, i_Row - 1, i_Col);

            b_IsBomb = mt_IsBomb(ref ia_Map, i_Row + 1, i_Col + 1, i_MaxR, int i_MaxC);
            if (b_IsBomb == false)
                mt_Addone(ref ia_Map, i_Row + 1, i_Col + 1);

            b_IsBomb = mt_IsBomb(ref ia_Map, i_Row, i_Col - 1, i_MaxR, int i_MaxC);
            if (b_IsBomb == false)
                mt_Addone(ref ia_Map, i_Row, i_Col - 1);

            b_IsBomb = mt_IsBomb(ref ia_Map, i_Row, i_Col + 1, i_MaxR, int i_MaxC);
            if (b_IsBomb == false)
                mt_Addone(ref ia_Map, i_Row, i_Col +1);

            b_IsBomb = mt_IsBomb(ref ia_Map, i_Row, i_Col + 1, i_MaxR, int i_MaxC);
            if (b_IsBomb == false)
                mt_Addone(ref ia_Map, i_Row, i_Col + 1);

            b_IsBomb = mt_IsBomb(ref ia_Map, i_Row + 1, i_Col - 1, i_MaxR, int i_MaxC);
            if (b_IsBomb == false)
                mt_Addone(ref ia_Map, i_Row + 1, i_Col - 1);

            b_IsBomb = mt_IsBomb(ref ia_Map, i_Row + 1, i_Col, i_MaxR, int i_MaxC);
            if (b_IsBomb == false)
                mt_Addone(ref ia_Map, i_Row + 1, i_Col);
            b_IsBomb = mt_IsBomb(ref ia_Map, i_Row + 1, i_Col + 1, i_MaxR, int i_MaxC);
            if (b_IsBomb == false)
                mt_Addone(ref ia_Map, i_Row - 1, i_Col - 1);
        }
        

        bool mt_IsBomb(ref char[,] ia_Map, int i_Row, int i_Col, int i_MaxR, int i_MaxC) {
            bool b_IsBomb = false;
            if (ia_Map[i_Row, i_Col] == '*') {
                b_IsBomb = true;
            }

            else if (i_Row < 0 || i_Row >= i_MaxR) {
                b_IsBomb = true;
            }
            else if (i_Col < 0 || i_Col >= i_MaxC){
                b_IsBomb = true;
            }

            return b_IsBomb;
        }
        void mt_Addone(ref char[,] ia_Map, int i_Row, int i_Col) {
            int IValue = Convert.ToInt32(ia_Map[i_Row, i_Col]);
            IValue++;
            ia_Map[i_Row,i_Col] = Convert.ToChar(IValue)
        }
    }
}