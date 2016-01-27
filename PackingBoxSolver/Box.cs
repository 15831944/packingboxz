using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingBoxSolver {

    /// <summary>
    /// BoxCoordinate represents the coordinates of a single cube in a piece.
    /// 
    /// All pieces are the same, however, there are 24 different orientations 
    /// which must be taken into account (e.g. piece standing up facing north, 
    /// laying down to the right facing east, etc.
    /// 
    /// All coordinates should consider that the end of the piece starts at 
    /// x = 0, y = 0, z = 0
    /// </summary>
    public sealed class BoxCoordinate {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public BoxCoordinate(int x, int y, int z) {
            X = x;
            Y = y;
            Z = z;
        }
    }

    /// <summary>
    /// The Pieces class does two things, it initializes every single piece orientation
    /// (e.g. pieces0, pieces1, etc), and allocates what piece orientation is legal for each cell
    /// in the box via a 3d array.
    /// 
    /// In the image link provided, the red cube represents the first cube which is always at 
    /// x = 0, y = 0, z = 0
    /// </summary>
    public sealed class Pieces {

        // http://i.imgur.com/6mFMU5J.png
        private static readonly BoxCoordinate[] pieces0 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(1, 0, 0),
            new BoxCoordinate(2, 0, 0),
            new BoxCoordinate(2, 1, 0),
            new BoxCoordinate(3, 1, 0)
        };

        // http://i.imgur.com/kme45CF.png
        private static readonly BoxCoordinate[] pieces1 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(1, 0, 0),
            new BoxCoordinate(2, 0, 0),
            new BoxCoordinate(2, 0, 1),
            new BoxCoordinate(3, 0, 1)
        };

        // http://i.imgur.com/DhF5IYl.png
        private static readonly BoxCoordinate[] pieces2 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(1, 0, 0),
            new BoxCoordinate(2, 0, 0),
            new BoxCoordinate(2, -1, 0),
            new BoxCoordinate(3, -1, 0)
        };

        // http://i.imgur.com/MG1G66n.png
        private static readonly BoxCoordinate[] pieces3 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(1, 0, 0),
            new BoxCoordinate(2, 0, 0),
            new BoxCoordinate(2, 0, -1),
            new BoxCoordinate(3, 0, -1)
        };

        // http://i.imgur.com/bxnwOIC.png
        private static readonly BoxCoordinate[] pieces4 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 0, 1),
            new BoxCoordinate(0, 0, 2),
            new BoxCoordinate(0, 1, 2),
            new BoxCoordinate(0, 1, 3)
        };

        // http://i.imgur.com/gbiB4eC.png
        private static readonly BoxCoordinate[] pieces5 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 0, 1),
            new BoxCoordinate(0, 0, 2),
            new BoxCoordinate(-1, 0, 2),
            new BoxCoordinate(-1, 0, 3)
        };

        // http://i.imgur.com/mwCrYT3.png
        private static readonly BoxCoordinate[] pieces6 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 0, 1),
            new BoxCoordinate(0, 0, 2),
            new BoxCoordinate(0, -1, 2),
            new BoxCoordinate(0, -1, 3)
        };

        // http://i.imgur.com/EQmgPGc.png
        private static readonly BoxCoordinate[] pieces7 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 0, 1),
            new BoxCoordinate(0, 0, 2),
            new BoxCoordinate(1, 0, 2),
            new BoxCoordinate(1, 0, 3)
        };

        // http://i.imgur.com/cm1vql3.png
        private static readonly BoxCoordinate[] pieces8 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(-1, 0, 0),
            new BoxCoordinate(-2, 0, 0),
            new BoxCoordinate(-2, 1, 0),
            new BoxCoordinate(-3, 1, 0)
        };

        // http://i.imgur.com/2RE1sdz.png
        private static readonly BoxCoordinate[] pieces9 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(-1, 0, 0),
            new BoxCoordinate(-2, 0, 0),
            new BoxCoordinate(-2, 0, -1),
            new BoxCoordinate(-3, 0, -1)
        };

        // http://i.imgur.com/dvdBLSW.png
        private static readonly BoxCoordinate[] pieces10 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(-1, 0, 0),
            new BoxCoordinate(-2, 0, 0),
            new BoxCoordinate(-2, -1, 0),
            new BoxCoordinate(-3, -1, 0)
        };

        // http://i.imgur.com/qg0BxU7.png
        private static readonly BoxCoordinate[] pieces11 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(-1, 0, 0),
            new BoxCoordinate(-2, 0, 0),
            new BoxCoordinate(-2, 0, 1),
            new BoxCoordinate(-3, 0, 1)
        };

        // http://i.imgur.com/FuHBeRU.png
        private static readonly BoxCoordinate[] pieces12 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 0, -1),
            new BoxCoordinate(0, 0, -2),
            new BoxCoordinate(0, 1, -2),
            new BoxCoordinate(0, 1, -3)
        };

        // http://i.imgur.com/MCg7drH.png
        private static readonly BoxCoordinate[] pieces13 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 0, -1),
            new BoxCoordinate(0, 0, -2),
            new BoxCoordinate(1, 0, -2),
            new BoxCoordinate(1, 0, -3)
        };

        // http://i.imgur.com/JXENmMc.png
        private static readonly BoxCoordinate[] pieces14 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 0, -1),
            new BoxCoordinate(0, 0, -2),
            new BoxCoordinate(0, -1, -2),
            new BoxCoordinate(0, -1, -3)
        };

        // http://i.imgur.com/ReC85sL.png
        private static readonly BoxCoordinate[] pieces15 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 0, -1),
            new BoxCoordinate(0, 0, -2),
            new BoxCoordinate(-1, 0, -2),
            new BoxCoordinate(-1, 0, -3)
        };

        // http://i.imgur.com/EOOB6sA.png
        private static readonly BoxCoordinate[] pieces16 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 1, 0),
            new BoxCoordinate(0, 2, 0),
            new BoxCoordinate(0, 2, 1),
            new BoxCoordinate(0, 3, 1)
        };

        // http://i.imgur.com/Vtg4KDF.png
        private static readonly BoxCoordinate[] pieces17 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 1, 0),
            new BoxCoordinate(0, 2, 0),
            new BoxCoordinate(-1, 2, 0),
            new BoxCoordinate(-1, 3, 0)
        };

        // http://i.imgur.com/6Txc4Ct.png
        private static readonly BoxCoordinate[] pieces18 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 1, 0),
            new BoxCoordinate(0, 2, 0),
            new BoxCoordinate(0, 2, -1),
            new BoxCoordinate(0, 3, -1)
        };

        // http://i.imgur.com/pCmEBNx.png
        private static readonly BoxCoordinate[] pieces19 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, 1, 0),
            new BoxCoordinate(0, 2, 0),
            new BoxCoordinate(1, 2, 0),
            new BoxCoordinate(1, 3, 0)
        };

        // http://i.imgur.com/AKy1jYX.png
        private static readonly BoxCoordinate[] pieces20 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, -1, 0),
            new BoxCoordinate(0, -2, 0),
            new BoxCoordinate(0, -2, -1),
            new BoxCoordinate(0, -3, -1)
        };

        // http://i.imgur.com/rRl87QY.png
        private static readonly BoxCoordinate[] pieces21 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, -1, 0),
            new BoxCoordinate(0, -2, 0),
            new BoxCoordinate(1, -2, 0),
            new BoxCoordinate(1, -3, 0)
        };

        // http://i.imgur.com/ZhVYL7D.png
        private static readonly BoxCoordinate[] pieces22 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, -1, 0),
            new BoxCoordinate(0, -2, 0),
            new BoxCoordinate(0, -2, 1),
            new BoxCoordinate(0, -3, 1)
        };

        // http://i.imgur.com/fwHi7N6.png
        private static readonly BoxCoordinate[] pieces23 = new BoxCoordinate[] {
            new BoxCoordinate(0, 0, 0),
            new BoxCoordinate(0, -1, 0),
            new BoxCoordinate(0, -2, 0),
            new BoxCoordinate(-1, -2, 0),
            new BoxCoordinate(-1, -3, 0)
        };

        // To store every possible piece orientation for each cell in the box.
        // The first dimension represents z, second y, third x
        public BoxCoordinate[][][] Piece { get; }

        public Pieces() {
            Piece = new BoxCoordinate[][][] {
                // All piece orientations at - z = 0, y = 0, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces4, pieces7, pieces16, pieces19 },
                // All piece orientations at - z = 0, y = 0, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces4, pieces5, pieces7, pieces16, pieces17, pieces19 },
                // All piece orientations at - z = 0, y = 0, x = 2
                new BoxCoordinate[][] { pieces4, pieces5, pieces7, pieces16, pieces17, pieces19 },
                // All piece orientations at - z = 0, y = 0, x = 3
                new BoxCoordinate[][] { pieces4, pieces5, pieces7, pieces8, pieces11, pieces16, pieces17, pieces19 },
                // All piece orientations at - z = 0, y = 0, x = 4
                new BoxCoordinate[][] { pieces4, pieces5, pieces8, pieces11, pieces16, pieces17 },

                // All piece orientations at - z = 0, y = 1, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces4, pieces6, pieces7, pieces16, pieces19 },
                // All piece orientations at - z = 0, y = 1, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces4, pieces5, pieces6, pieces7, pieces16, pieces17, pieces19 },
                // All piece orientations at - z = 0, y = 1, x = 2
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces16, pieces17, pieces19 },
                // All piece orientations at - z = 0, y = 1, x = 3
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces10, pieces11, pieces16, pieces17, pieces19 },
                // All piece orientations at - z = 0, y = 1, x = 4
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces8, pieces10, pieces11, pieces16, pieces17 },

                // All piece orientations at - z = 0, y = 2, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces4, pieces6, pieces7 },
                // All piece orientations at - z = 0, y = 2, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces4, pieces5, pieces6, pieces7 },
                // All piece orientations at - z = 0, y = 2, x = 2
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7 },
                // All piece orientations at - z = 0, y = 2, x = 3
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces10, pieces11 },
                // All piece orientations at - z = 0, y = 2, x = 4
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces8, pieces10, pieces11 },

                // All piece orientations at - z = 0, y = 3, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces4, pieces6, pieces7, pieces21, pieces22 },
                // All piece orientations at - z = 0, y = 3, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces4, pieces5, pieces6, pieces7, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 0, y = 3, x = 2
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 0, y = 3, x = 3
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces10, pieces11, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 0, y = 3, x = 4
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces8, pieces10, pieces11, pieces22, pieces23 },

                // All piece orientations at - z = 0, y = 4, x = 0
                new BoxCoordinate[][] { pieces1, pieces2, pieces6, pieces7, pieces21, pieces22 },
                // All piece orientations at - z = 0, y = 4, x = 1
                new BoxCoordinate[][] { pieces1, pieces2, pieces5, pieces6, pieces7, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 0, y = 4, x = 2
                new BoxCoordinate[][] { pieces5, pieces6, pieces7, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 0, y = 4, x = 3
                new BoxCoordinate[][] { pieces5, pieces6, pieces7, pieces10, pieces11, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 0, y = 4, x = 4
                new BoxCoordinate[][] { pieces5, pieces6, pieces10, pieces11, pieces22, pieces23 },

                // All piece orientations at - z = 1, y = 0, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces3, pieces4, pieces7, pieces16, pieces18, pieces19 },
                // All piece orientations at - z = 1, y = 0, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces3, pieces4, pieces5, pieces7, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 1, y = 0, x = 2
                new BoxCoordinate[][] { pieces4, pieces5, pieces7, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 1, y = 0, x = 3
                new BoxCoordinate[][] { pieces4, pieces5, pieces7, pieces8, pieces9, pieces11, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 1, y = 0, x = 4
                new BoxCoordinate[][] { pieces4, pieces5, pieces8, pieces9, pieces11, pieces16, pieces17, pieces18 },

                // All piece orientations at - z = 1, y = 1, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces6, pieces7, pieces16, pieces18, pieces19 },
                // All piece orientations at - z = 1, y = 1, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces5, pieces6, pieces7, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 1, y = 1, x = 2
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 1, y = 1, x = 3
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces9, pieces10, pieces11, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 1, y = 1, x = 4
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces8, pieces9, pieces10, pieces11, pieces16, pieces17, pieces18 },

                // All piece orientations at - z = 1, y = 2, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces6, pieces7 },
                // All piece orientations at - z = 1, y = 2, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces5, pieces6, pieces7 },
                // All piece orientations at - z = 1, y = 2, x = 2
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7 },
                // All piece orientations at - z = 1, y = 2, x = 3
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces9, pieces10, pieces11 },
                // All piece orientations at - z = 1, y = 2, x = 4
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces8, pieces9, pieces10, pieces11 },

                // All piece orientations at - z = 1, y = 3, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces6, pieces7, pieces20, pieces21, pieces22 },
                // All piece orientations at - z = 1, y = 3, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces4, pieces5, pieces6, pieces7, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 1, y = 3, x = 2
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 1, y = 3, x = 3
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces7, pieces8, pieces9, pieces10, pieces11, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 1, y = 3, x = 4
                new BoxCoordinate[][] { pieces4, pieces5, pieces6, pieces8, pieces9, pieces10, pieces11, pieces20, pieces22, pieces23 },

                // All piece orientations at - z = 1, y = 4, x = 0
                new BoxCoordinate[][] { pieces1, pieces2, pieces3, pieces6, pieces7, pieces20, pieces21, pieces22 },
                // All piece orientations at - z = 1, y = 4, x = 1
                new BoxCoordinate[][] { pieces1, pieces2, pieces3, pieces5, pieces6, pieces7, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 1, y = 4, x = 2
                new BoxCoordinate[][] { pieces5, pieces6, pieces7, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 1, y = 4, x = 3
                new BoxCoordinate[][] { pieces5, pieces6, pieces7, pieces9, pieces10, pieces11, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 1, y = 4, x = 4
                new BoxCoordinate[][] { pieces5, pieces6, pieces9, pieces10, pieces11, pieces20, pieces22, pieces23 },

                // All piece orientations at - z = 2, y = 0, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces3, pieces16, pieces18, pieces19 },
                // All piece orientations at - z = 2, y = 0, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces3, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 2, y = 0, x = 2
                new BoxCoordinate[][] { pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 2, y = 0, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces11, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 2, y = 0, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces11, pieces16, pieces17, pieces18 },

                // All piece orientations at - z = 2, y = 1, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces16, pieces18, pieces19 },
                // All piece orientations at - z = 2, y = 1, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 2, y = 1, x = 2
                new BoxCoordinate[][] { pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 2, y = 1, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 2, y = 1, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces16, pieces17, pieces18 },

                // All piece orientations at - z = 2, y = 2, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3 },
                // All piece orientations at - z = 2, y = 2, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3 },
                // All piece orientations at - z = 2, y = 2, x = 2 
                // - Since this is in the middle of the box, all piece orientations go beyond the box bounds
                // - so no legal pieces can fit
                new BoxCoordinate[][] { },
                // All piece orientations at - z = 2, y = 2, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11 },
                // All piece orientations at - z = 2, y = 2, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11 },

                // All piece orientations at - z = 2, y = 3, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces20, pieces21, pieces22 },
                // All piece orientations at - z = 2, y = 3, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 2, y = 3, x = 2
                new BoxCoordinate[][] { pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 2, y = 3, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 2, y = 3, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces20, pieces22, pieces23 },

                // All piece orientations at - z = 2, y = 4, x = 0
                new BoxCoordinate[][] { pieces1, pieces2, pieces3, pieces20, pieces21, pieces22 },
                // All piece orientations at - z = 2, y = 4, x = 1
                new BoxCoordinate[][] { pieces1, pieces2, pieces3, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 2, y = 4, x = 2
                new BoxCoordinate[][] { pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 2, y = 4, x = 3
                new BoxCoordinate[][] { pieces9, pieces10, pieces11, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 2, y = 4, x = 4
                new BoxCoordinate[][] { pieces9, pieces10, pieces11, pieces20, pieces22, pieces23 },

                // All piece orientations at - z = 3, y = 0, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces3, pieces12, pieces13, pieces16, pieces18, pieces19 },
                // All piece orientations at - z = 3, y = 0, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces3, pieces12, pieces13, pieces15, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 3, y = 0, x = 2
                new BoxCoordinate[][] { pieces12, pieces13, pieces15, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 3, y = 0, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces11, pieces12, pieces13, pieces15, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 3, y = 0, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces11, pieces12, pieces15, pieces16, pieces17, pieces18 },

                // All piece orientations at - z = 3, y = 1, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces16, pieces18, pieces19 },
                // All piece orientations at - z = 3, y = 1, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 3, y = 1, x = 2
                new BoxCoordinate[][] { pieces12, pieces13, pieces14, pieces15, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 3, y = 1, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces13, pieces14, pieces15, pieces16, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 3, y = 1, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces14, pieces15, pieces16, pieces17, pieces18 },

                // All piece orientations at - z = 3, y = 2, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14 },
                // All piece orientations at - z = 3, y = 2, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15 },
                // All piece orientations at - z = 3, y = 2, x = 2
                new BoxCoordinate[][] { pieces12, pieces13, pieces14, pieces15 },
                // All piece orientations at - z = 3, y = 2, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces13, pieces14, pieces15 },
                // All piece orientations at - z = 3, y = 2, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces14, pieces15 },

                // All piece orientations at - z = 3, y = 3, x = 0
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces20, pieces21, pieces22 },
                // All piece orientations at - z = 3, y = 3, x = 1
                new BoxCoordinate[][] { pieces0, pieces1, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 3, y = 3, x = 2
                new BoxCoordinate[][] { pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 3, y = 3, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 3, y = 3, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces11, pieces12, pieces14, pieces15, pieces20, pieces22, pieces23 },

                // All piece orientations at - z = 3, y = 4, x = 0
                new BoxCoordinate[][] { pieces1, pieces2, pieces3, pieces13, pieces14, pieces20, pieces21, pieces22 },
                // All piece orientations at - z = 3, y = 4, x = 1
                new BoxCoordinate[][] { pieces1, pieces2, pieces3, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 3, y = 4, x = 2
                new BoxCoordinate[][] { pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 3, y = 4, x = 3
                new BoxCoordinate[][] { pieces9, pieces10, pieces11, pieces13, pieces14, pieces15, pieces20, pieces21, pieces22, pieces23 },
                // All piece orientations at - z = 3, y = 4, x = 4
                new BoxCoordinate[][] { pieces9, pieces10, pieces11, pieces14, pieces15, pieces20, pieces22, pieces23 },

                // All piece orientations at - z = 4, y = 0, x = 0
                new BoxCoordinate[][] { pieces0, pieces3, pieces12, pieces13, pieces18, pieces19 },
                // All piece orientations at - z = 4, y = 0, x = 1
                new BoxCoordinate[][] { pieces0, pieces3, pieces12, pieces13, pieces15, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 4, y = 0, x = 2
                new BoxCoordinate[][] { pieces12, pieces13, pieces15, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 4, y = 0, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces12, pieces13, pieces15, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 4, y = 0, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces12, pieces15, pieces17, pieces18 },

                // All piece orientations at - z = 4, y = 1, x = 0
                new BoxCoordinate[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces18, pieces19 },
                // All piece orientations at - z = 4, y = 1, x = 1
                new BoxCoordinate[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 4, y = 1, x = 2
                new BoxCoordinate[][] { pieces12, pieces13, pieces14, pieces15, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 4, y = 1, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces12, pieces13, pieces14, pieces15, pieces17, pieces18, pieces19 },
                // All piece orientations at - z = 4, y = 1, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces12, pieces14, pieces15, pieces17, pieces18 },

                // All piece orientations at - z = 4, y = 2, x = 0
                new BoxCoordinate[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14 },
                // All piece orientations at - z = 4, y = 2, x = 1
                new BoxCoordinate[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15 },
                // All piece orientations at - z = 4, y = 2, x = 2
                new BoxCoordinate[][] { pieces12, pieces13, pieces14, pieces15 },
                // All piece orientations at - z = 4, y = 2, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces12, pieces13, pieces14, pieces15 },
                // All piece orientations at - z = 4, y = 2, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces12, pieces14, pieces15 },

                // All piece orientations at - z = 4, y = 3, x = 0
                new BoxCoordinate[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces20, pieces21 },
                // All piece orientations at - z = 4, y = 3, x = 1
                new BoxCoordinate[][] { pieces0, pieces2, pieces3, pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
                // All piece orientations at - z = 4, y = 3, x = 2
                new BoxCoordinate[][] { pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
                // All piece orientations at - z = 4, y = 3, x = 3
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces12, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
                // All piece orientations at - z = 4, y = 3, x = 4
                new BoxCoordinate[][] { pieces8, pieces9, pieces10, pieces12, pieces14, pieces15, pieces20, pieces23 },

                // All piece orientations at - z = 4, y = 4, x = 0
                new BoxCoordinate[][] { pieces2, pieces3, pieces13, pieces14, pieces20, pieces21 },
                // All piece orientations at - z = 4, y = 4, x = 1
                new BoxCoordinate[][] { pieces2, pieces3, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
                // All piece orientations at - z = 4, y = 4, x = 2
                new BoxCoordinate[][] { pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
                // All piece orientations at - z = 4, y = 4, x = 3
                new BoxCoordinate[][] { pieces9, pieces10, pieces13, pieces14, pieces15, pieces20, pieces21, pieces23 },
                // All piece orientations at - z = 4, y = 4, x = 4
                new BoxCoordinate[][] { pieces9, pieces10, pieces14, pieces15, pieces20, pieces23 }
            };
        }
    }

    /// <summary>
    /// This represents the box we are trying to fill with 25 pieces. The box is represented by a 3d array (5x5x5) 
    /// all initialized to -1 (NoPiece). The array is 3d so that we can simulate z, y, x coordinates.
    /// 
    /// The simulation works by iterating over all the cells in the box. It will then check if that particular cell
    /// equals NoPiece. If it is true, then it will try and iterate over all the possible orientations for that cell.
    /// 
    /// If a piece orientation can be fit, then the array indexes at 5 points representing the piece will be set to 
    /// CurrentCount, which will be incremented afterwards once the piece is set. After a piece is set, Simulate() will 
    /// make a recursive call on itself and repeat the cycle. 
    /// 
    /// If no piece orientation can fit, then it will continue onto the next cell in the box. 
    /// If there is no possible piece which can fit, UnPlace() will be called which removes the last placed piece from the box,
    /// and decrements CurrentCount. Once that happens, the program will naturally full back onto the previous stack of Simulate()
    /// and try to continue on fitting in pieces from where it left off.
    /// 
    /// The simulation finishes when CurrentCount equals 25 (NumPieces)
    /// 
    /// </summary>
    public sealed class Box {
        public const int NumPieces = 25;
        public const int PieceSize = 5;
        public const int NoPiece = -1;

        private int highCount;
        private int currentCount;
        private int lowCount;
        private int iter = 0;

        private int[,,] boxContainer;

        private Pieces pieces;

        private BoxCoordinate[] log;

        public Box() {
            pieces = new Pieces();
            boxContainer = new int[PieceSize, PieceSize, PieceSize];

            // Initialize array with NoPiece
            for (int z = 0; z < PieceSize; z++) {
                for (int y = 0; y < PieceSize; y++) {
                    for (int x = 0; x < PieceSize; x++) {
                        boxContainer[z, y, x] = NoPiece;
                    }
                }
            }

            // This is used in Simulate_Two, for keeping track of previous iterations for back tracking
            log = new BoxCoordinate[NumPieces];
            
            for (int i = 0; i < log.Length; i++) {
                log[i] = new BoxCoordinate(0, 0, 0);
            }

            currentCount = 0;
            highCount = currentCount;
            lowCount = currentCount;           
        }

        /// <summary>
        /// This method will run the simulation of trying to place 25 pieces into a box. This is a recursive solution
        /// and it is my first simulate method I wrote, but after developing Simulate_Two, I'm not sure if this is 
        /// correct. More info on this in Simulate_Two method comment.
        /// </summary>
        public void Simulate() {
            // Iterate through all the cells
            for (int z = 0; z < PieceSize && currentCount < NumPieces; z++) {
                for (int y = 0; y < PieceSize && currentCount < NumPieces; y++) {
                    for (int x = 0; x < PieceSize && currentCount < NumPieces; x++) {
                        // If cell hasn't been set
                        if (boxContainer[z, y, x] == NoPiece) {
                            // If a piece has been placed
                            if (place(x, y, z, pieces.Piece[(z * NumPieces) + (y * PieceSize) + x])) {
                                // Go and try to fit the next piece
                                update();
                                Simulate();
                            }
                        }
                    }
                }
            }

            if (currentCount != NumPieces) {
                unPlace();
            }
        }

        /// <summary>
        /// This is an iterative approach to the simulation. When I ran this, not only was I able to get up to 23 
        /// in currentCount very quickly (never been able to do so in Simulate), but lowCount was able to go lower 
        /// than what Simulate could which has me confused on which one has been implemented correctly.
        /// </summary>
        public void Simulate_Two() {
            bool placed = false;

            while (currentCount < NumPieces) {
                placed = false;
                for (int z = log[currentCount].Z; z < PieceSize && !placed; z++) {
                    for (int y = log[currentCount].Y; y < PieceSize && !placed; y++) {
                        for (int x = log[currentCount].X; x < PieceSize && !placed; x++) {
                            if (boxContainer[z, y, x] == NoPiece) {
                                if (place(x, y, z, pieces.Piece[(z * NumPieces) + (y * PieceSize) + x])) {
                                    // Go and try to fit the next piece
                                    updateLog(x, y, z);

                                    placed = true;

                                    update();
                                }
                            }
                        }
                    }
                }

                if (!placed) {
                    updateLog(0, 0, 0);
                    unPlace();
                    log[currentCount].X++;
                }
            }
        }

        /// <summary>
        /// This method will print each layer of the box in the console alongside additional 
        /// debugging information like current/high/lowCount. It isn't recommended to call 
        /// this method too frequently as writing to console is an expensive operation
        /// </summary>
        private void print() {
            Console.Write("Current Count: {0}, Highest Count: {1}, Lowest Count: {2}", currentCount, highCount, lowCount);

            for (int z = 0; z < PieceSize; z++) {
                Console.WriteLine();
                for (int y = 0; y < PieceSize; y++) {
                    Console.WriteLine();
                    for (int x = 0; x < PieceSize; x++) {
                        int a = boxContainer[z, y, x];

                        Console.Write("{0}{1} ", a >= 0 && a < 10 ? " " : "", boxContainer[z, y, x]);
                    }
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// This method will try and place a piece at the specified z/y/z coordinates. If it can, this method
        /// will place the piece at that position and return true, otherwise will return false.
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        /// <param name="collection">Possible pieces that can go into that position</param>
        /// <returns>If a piece can fit at that specified location</returns>
        private bool place(int x, int y, int z, BoxCoordinate[][] collection) {
            foreach (BoxCoordinate[] pieces in collection) {
                // This is so valid never sets to true as no pieces will skip foreach loop
                if (pieces.Length == 0) continue;

                bool valid = true;

                foreach (BoxCoordinate piece in pieces) {
                    // If cell has already been set, move onto next piece orientation
                    if (boxContainer[piece.Z + z, piece.Y + y, piece.X + x] != NoPiece) {
                        valid = false;
                        break;
                    }
                }

                // If found a place for a piece, set that piece equal to CurrentCount, then increment
                if (valid) {
                    foreach (BoxCoordinate piece in pieces) {
                        boxContainer[piece.Z + z, piece.Y + y, piece.X + x] = currentCount;
                    }

                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// The main reason for this method is to update currentCount, but it is also convenient to update 
        /// debugging variables in here as well
        /// </summary>
        private void update() {
            currentCount++;

            // Below can be altered, used for debugging messages
            iter++;

            if (lowCount > currentCount) {
                lowCount = currentCount;
            }

            if (currentCount > highCount) {
                highCount = currentCount;
                print();
                lowCount = currentCount;
            }

            if (iter > 10000000) {
                print();
                iter = 0;
                lowCount = currentCount;
            }
        }

        /// <summary>
        /// This method is used for getting rid of the last placed piece from the box
        /// </summary>
        private void unPlace() {
            int count = 0;

            for (int z = 0; z < PieceSize && count < PieceSize; z++) {
                for (int y = 0; y < PieceSize && count < PieceSize; y++) {
                    for (int x = 0; x < PieceSize && count < PieceSize; x++) {
                        // If cell equals to latest piece, set to NoPiece
                        if (boxContainer[z, y, x] == currentCount - 1) {
                            boxContainer[z, y, x] = NoPiece;
                            count++;
                        }
                    }
                }
            }

            currentCount--;
        }

        /// <summary>
        /// Simple wrapper method for updating the log
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        private void updateLog(int x, int y, int z) {
            log[currentCount].X = x;
            log[currentCount].Y = y;
            log[currentCount].Z = z;
        }


    }
}
