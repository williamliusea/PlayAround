Given a 2-D MxN matrix having each value as difficulty for the block

Given a 2-D MxN matrix having each value as difficulty for the block. A frog is starting from a point Matrix[0][0] and will have to reach Matrix[M-1][N-1]. It can jump any step in one go [ 1, 2, ..... M-1] horizontally OR [ 1,2,3,.... N-1] vertically Each difficulty value is positive. Write code to give path trace for frog. Two structure to use -

struct node { int x; int y; struct node *next; };

struct path { int difficulty; struct node *pathlink; }

Ex matrix - 4X4 matrix

7 9 2 11 13 23 1 3 14 11 20 6 22 44 3 15

Minimum difficulty = 7 (a[0][0])+ 2(a[0][2]) +3(a[3][2])+15(a[3][3]) = 27 Path trace will have = 7->2->3->15
