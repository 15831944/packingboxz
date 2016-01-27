using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingBoxSolver {

    class MainProgram {
        static Box box;

        static void Main(string[] args) {
            box = new Box();

            // Use one or the other
            //box.Simulate();
            box.Simulate_Two();

            Console.ReadKey();
        }
    }


    //class Program {
    //    static BoxPiece[][][] Piece;

    //    #region Pieces Init
    //    static readonly BoxPiece[] pieces0 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(1, 0, 0),
    //        new BoxPiece(2, 0, 0),
    //        new BoxPiece(2, 1, 0),
    //        new BoxPiece(3, 1, 0)
    //    };

    //    static readonly BoxPiece[] pieces1 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(1, 0, 0),
    //        new BoxPiece(2, 0, 0),
    //        new BoxPiece(2, 0, 1),
    //        new BoxPiece(3, 0, 1)
    //    };

    //    static readonly BoxPiece[] pieces2 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(1, 0, 0),
    //        new BoxPiece(2, 0, 0),
    //        new BoxPiece(2, -1, 0),
    //        new BoxPiece(3, -1, 0)
    //    };


    //    static readonly BoxPiece[] pieces3 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(1, 0, 0),
    //        new BoxPiece(2, 0, 0),
    //        new BoxPiece(2, 0, -1),
    //        new BoxPiece(3, 0, -1)
    //    };

    //    static readonly BoxPiece[] pieces4 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 0, 1),
    //        new BoxPiece(0, 0, 2),
    //        new BoxPiece(0, 1, 2),
    //        new BoxPiece(0, 1, 3)
    //    };

    //    static readonly BoxPiece[] pieces5 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 0, 1),
    //        new BoxPiece(0, 0, 2),
    //        new BoxPiece(-1, 0, 2),
    //        new BoxPiece(-1, 0, 3)
    //    };

    //    static readonly BoxPiece[] pieces6 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 0, 1),
    //        new BoxPiece(0, 0, 2),
    //        new BoxPiece(0, -1, 2),
    //        new BoxPiece(0, -1, 3)
    //    };

    //    static readonly BoxPiece[] pieces7 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 0, 1),
    //        new BoxPiece(0, 0, 2),
    //        new BoxPiece(1, 0, 2),
    //        new BoxPiece(1, 0, 3)
    //    };

    //    static readonly BoxPiece[] pieces8 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(-1, 0, 0),
    //        new BoxPiece(-2, 0, 0),
    //        new BoxPiece(-2, 1, 0),
    //        new BoxPiece(-3, 1, 0)
    //    };

    //    static readonly BoxPiece[] pieces9 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(-1, 0, 0),
    //        new BoxPiece(-2, 0, 0),
    //        new BoxPiece(-2, 0, -1),
    //        new BoxPiece(-3, 0, -1)
    //    };

    //    static readonly BoxPiece[] pieces10 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(-1, 0, 0),
    //        new BoxPiece(-2, 0, 0),
    //        new BoxPiece(-2, -1, 0),
    //        new BoxPiece(-3, -1, 0)
    //    };

    //    static readonly BoxPiece[] pieces11 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(-1, 0, 0),
    //        new BoxPiece(-2, 0, 0),
    //        new BoxPiece(-2, 0, 1),
    //        new BoxPiece(-3, 0, 1)
    //    };

    //    static readonly BoxPiece[] pieces12 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 0, -1),
    //        new BoxPiece(0, 0, -2),
    //        new BoxPiece(0, 1, -2),
    //        new BoxPiece(0, 1, -3)
    //    };

    //    static readonly BoxPiece[] pieces13 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 0, -1),
    //        new BoxPiece(0, 0, -2),
    //        new BoxPiece(1, 0, -2),
    //        new BoxPiece(1, 0, -3)
    //    };

    //    static readonly BoxPiece[] pieces14 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 0, -1),
    //        new BoxPiece(0, 0, -2),
    //        new BoxPiece(0, -1, -2),
    //        new BoxPiece(0, -1, -3)
    //    };

    //    static readonly BoxPiece[] pieces15 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 0, -1),
    //        new BoxPiece(0, 0, -2),
    //        new BoxPiece(-1, 0, -2),
    //        new BoxPiece(-1, 0, -3)
    //    };

    //    static readonly BoxPiece[] pieces16 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 1, 0),
    //        new BoxPiece(0, 2, 0),
    //        new BoxPiece(0, 2, 1),
    //        new BoxPiece(0, 3, 1)
    //    };

    //    static readonly BoxPiece[] pieces17 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 1, 0),
    //        new BoxPiece(0, 2, 0),
    //        new BoxPiece(-1, 2, 0),
    //        new BoxPiece(-1, 3, 0)
    //    };

    //    static readonly BoxPiece[] pieces18 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 1, 0),
    //        new BoxPiece(0, 2, 0),
    //        new BoxPiece(0, 2, -1),
    //        new BoxPiece(0, 3, -1)
    //    };

    //    static readonly BoxPiece[] pieces19 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, 1, 0),
    //        new BoxPiece(0, 2, 0),
    //        new BoxPiece(1, 2, 0),
    //        new BoxPiece(1, 3, 0)
    //    };

    //    static readonly BoxPiece[] pieces20 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, -1, 0),
    //        new BoxPiece(0, -2, 0),
    //        new BoxPiece(0, -2, -1),
    //        new BoxPiece(0, -3, -1)
    //    };

    //    static readonly BoxPiece[] pieces21 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, -1, 0),
    //        new BoxPiece(0, -2, 0),
    //        new BoxPiece(1, -2, 0),
    //        new BoxPiece(1, -3, 0)
    //    };

    //    static readonly BoxPiece[] pieces22 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, -1, 0),
    //        new BoxPiece(0, -2, 0),
    //        new BoxPiece(0, -2, 1),
    //        new BoxPiece(0, -3, 1)
    //    };

    //    static readonly BoxPiece[] pieces23 = new BoxPiece[] {
    //        new BoxPiece(0, 0, 0),
    //        new BoxPiece(0, -1, 0),
    //        new BoxPiece(0, -2, 0),
    //        new BoxPiece(-1, -2, 0),
    //        new BoxPiece(-1, -3, 0)
    //    };

    //    #endregion

    //    public const int NumPieces = 25;
    //    public const int PieceSize = 5;
    //    public const int NoPiece = -1;

    //    static int[,,] Box;

    //    static int CurrentCount;
    //    static int HighCount;
    //    static int CurrentIteration = 0;

    //    //static void Main(string[] args) {
    //    //    Box = new int[PieceSize, PieceSize, PieceSize];

    //    //    for (int z = 0; z < PieceSize; z++) {
    //    //        for (int y = 0; y < PieceSize; y++) {
    //    //            for (int x = 0; x < PieceSize; x++) {
    //    //                Box[z, y, x] = NoPiece;
    //    //            }
    //    //        }
    //    //    }

    //    //    CurrentCount = 0;
    //    //    HighCount = 0;

    //    //    #region Piece Collection Init
    //    //    Piece = new BoxPiece[][][] {
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces4, pieces7, pieces16, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces4, pieces5, pieces7, pieces16, pieces17, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces7, pieces16, pieces17, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces7, pieces8, pieces11, pieces16, pieces17, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces8, pieces11, pieces16, pieces17 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces4, pieces6, pieces7, pieces16, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces4, pieces5, pieces6, pieces7, pieces16, pieces17, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces16, pieces17, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces10, pieces11, pieces16, pieces17, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces8, pieces10, pieces11, pieces16, pieces17 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces4, pieces6, pieces7 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces4, pieces5, pieces6, pieces7 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces10, pieces11 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces8, pieces10, pieces11 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces4, pieces6, pieces7, pieces21, pieces22 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces4, pieces5, pieces6, pieces7, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces10, pieces11, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces8, pieces10, pieces11, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces1, pieces2, pieces6, pieces7, pieces21, pieces22 },
    //    //        new BoxPiece[][] { pieces1, pieces2, pieces5, pieces6, pieces7, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces5, pieces6, pieces7, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces5, pieces6, pieces7, pieces10, pieces11, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces5, pieces6, pieces10, pieces11, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces3, pieces4, pieces7, pieces16, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces3, pieces4, pieces5, pieces7, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces7, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces7, pieces8, pieces9, pieces11, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces8, pieces9, pieces11, pieces16, pieces17, pieces18 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces6, pieces7, pieces16, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces5, pieces6, pieces7, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces9, pieces10, pieces11, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces8, pieces9, pieces10, pieces11, pieces16, pieces17, pieces18 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces6, pieces7 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces5, pieces6, pieces7 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces9, pieces10, pieces11 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces8, pieces9, pieces10, pieces11 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces6, pieces7, pieces20, pieces21, pieces22 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces5, pieces6, pieces7, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces9, pieces10, pieces11, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces4, pieces5, pieces6, pieces8, pieces9, pieces10, pieces11, pieces20, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces1, pieces2, pieces3, pieces6, pieces7, pieces20, pieces21, pieces22 },
    //    //        new BoxPiece[][] { pieces1, pieces2, pieces3, pieces5, pieces6, pieces7, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces5, pieces6, pieces7, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces5, pieces6, pieces7, pieces9, pieces10, pieces11, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces5, pieces6, pieces9, pieces10, pieces11, pieces20, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces3, pieces16, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces3, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces11, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces11, pieces16, pieces17, pieces18 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces16, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces16, pieces17, pieces18 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3 },
    //    //        new BoxPiece[][] { },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces20, pieces21, pieces22 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces20, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces1, pieces2, pieces3, pieces20, pieces21, pieces22 },
    //    //        new BoxPiece[][] { pieces1, pieces2, pieces3, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces9, pieces10, pieces11, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces9, pieces10, pieces11, pieces20, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces3, pieces12, pieces13, pieces16, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces3, pieces12, pieces13, pieces15, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces12, pieces13, pieces15, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces11, pieces12, pieces13, pieces15, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces11, pieces12, pieces15, pieces16, pieces17, pieces18 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces16, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces12, pieces13, pieces14, pieces15, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces13, pieces14, pieces15, pieces16, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces14, pieces15, pieces16, pieces17, pieces18 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15 },
    //    //        new BoxPiece[][] { pieces12, pieces13, pieces14, pieces15 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces13, pieces14, pieces15 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces14, pieces15 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces20, pieces21, pieces22 },
    //    //        new BoxPiece[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces14, pieces15, pieces20, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces1, pieces2, pieces3, pieces13, pieces14, pieces20, pieces21, pieces22 },
    //    //        new BoxPiece[][] { pieces1, pieces2, pieces3, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces9, pieces10, pieces11, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces9, pieces10, pieces11, pieces14, pieces15, pieces20, pieces22, pieces23 },
    //    //        new BoxPiece[][] { pieces0, pieces3, pieces12, pieces13, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces3, pieces12, pieces13, pieces15, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces12, pieces13, pieces15, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces12, pieces13, pieces15, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces12, pieces15, pieces17, pieces18 },
    //    //        new BoxPiece[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces12, pieces13, pieces14, pieces15, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces12, pieces13, pieces14, pieces15, pieces17, pieces18, pieces19 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces12, pieces14, pieces15, pieces17, pieces18 },
    //    //        new BoxPiece[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14 },
    //    //        new BoxPiece[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15 },
    //    //        new BoxPiece[][] { pieces12, pieces13, pieces14, pieces15 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces12, pieces13, pieces14, pieces15 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces12, pieces14, pieces15 },
    //    //        new BoxPiece[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces20, pieces21 },
    //    //        new BoxPiece[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
    //    //        new BoxPiece[][] { pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
    //    //        new BoxPiece[][] { pieces8, pieces9, pieces10, pieces12, pieces14, pieces15, pieces20, pieces23 },
    //    //        new BoxPiece[][] { pieces2, pieces3, pieces13, pieces14, pieces20, pieces21 },
    //    //        new BoxPiece[][] { pieces2, pieces3, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
    //    //        new BoxPiece[][] { pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
    //    //        new BoxPiece[][] { pieces9, pieces10, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
    //    //        new BoxPiece[][] { pieces9, pieces10, pieces14, pieces15, pieces20, pieces23 }
    //    //    };
    //    //    #endregion

    //    //    Simulate();
    //    //    Print();

    //    //    Console.WriteLine("Simulation finished, press enter to continue...");
    //    //    Console.ReadLine();
    //    //}

    //    static void Simulate() {
    //        for (int z = 0; z < PieceSize && CurrentCount < NumPieces; z++) {
    //            for (int y = 0; y < PieceSize && CurrentCount < NumPieces; y++) {
    //                for (int x = 0; x < PieceSize && CurrentCount < NumPieces; x++) {
    //                    if (Box[z, y, x] == NoPiece) {
    //                        if (Place(x, y, z, Piece[(z * NumPieces) + (y * PieceSize) + x])) {
    //                            Simulate();
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        if (CurrentCount != NumPieces) {
    //            UnPlace();
    //        } 
    //    }

    //    static bool Place(int x, int y, int z, BoxPiece[][] pieceCollection) {
    //        foreach (BoxPiece[] pieces in pieceCollection) {
    //            if (pieces.Length == 0) continue;

    //            bool valid = true;
    //            foreach (BoxPiece piece in pieces) {
    //                if (Box[piece.Z + z, piece.Y + y, piece.X + x] != NoPiece) {
    //                    valid = false;
    //                    break;
    //                }
    //            }

    //            if (valid) {
    //                CurrentIteration++;
    //                foreach (BoxPiece piece in pieces) {
    //                    Box[piece.Z + z, piece.Y + y, piece.X + x] = CurrentCount;
    //                }

    //                CurrentCount++;

    //                if (CurrentCount > HighCount) {
    //                    HighCount = CurrentCount;
    //                    Console.WriteLine("High Count: {0}", HighCount);
    //                }

    //                return true;
    //            }

    //            if (CurrentIteration > 10000000) {
    //                Print();
    //                CurrentIteration = 0;
    //            }
    //        }

    //        return false;
    //    }

    //    static void UnPlace() {
    //        int count = 0;

    //        for (int z = 0; z < PieceSize && count < PieceSize; z++) {
    //            for (int y = 0; y < PieceSize && count < PieceSize; y++) {
    //                for (int x = 0; x < PieceSize && count < PieceSize; x++) {
    //                    if (Box[z, y, x] == CurrentCount - 1) {
    //                        Box[z, y, x] = NoPiece;
    //                        count++;
    //                    }
    //                }
    //            }
    //        }

    //        CurrentCount--;
    //    }

    //    static void Print() {
    //        Console.WriteLine("High Count: {0}", HighCount);
    //        Console.Write("Current Count: {0}", CurrentCount);

    //        for (int z = 0; z < PieceSize; z++) {
    //            Console.WriteLine();
    //            for (int y = 0; y < PieceSize; y++) {
    //                Console.WriteLine();
    //                for (int x = 0; x < PieceSize; x++) {
    //                    int a = Box[z, y, x];

    //                    Console.Write("{0}{1} ", a >= 0 && a < 10 ? " ": "", Box[z, y, x]);
    //                }
    //            }
    //        }

    //        Console.WriteLine();
    //    }

    //}
}
