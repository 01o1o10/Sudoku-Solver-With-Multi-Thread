#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <locale.h>
#include <conio.h>

struct nokta
{
    int x;
    int y;
};

void sudoku_yazdir(int sudoku[9][9]);
void hesapla(int sudoku[9][9]);

int main()
{
    setlocale(LC_ALL, "Turkish");
    int sudoku[9][9];
    int i, j;

    for(i = 0; i < 9; i++){
        for(j = 0; j < 9; j++){
            sudoku[i][j] = NULL;
        }
    }

    FILE *dosya;
    if((dosya = fopen("ornek2/sudoku.txt", "r")) == NULL){
        printf("Dosya açýlamadý!");
        exit(0);
    }

    char c;
    for(i = 0; i < 9; i++){
        for(j = 0; j < 9; j++){
            c = fgetc(dosya);
            if(c != EOF && c != '*'){
                sudoku[i][j] = c - '0';
            }
        }
        c = fgetc(dosya);
    }

    sudoku_yazdir(sudoku);
    hesapla(sudoku);

    return 0;
}

void sudoku_yazdir(int sudoku[9][9])
{
    int i, j;

    printf("+-------+-------+-------+");
    for(i = 0; i < 9; i++){
        printf("\n|");
        for(j = 0; j < 9; j ++){
            if(sudoku[i][j] != NULL){
                printf(" %d", sudoku[i][j]);
            }
            else{
                printf("  ");
            }
            if((j+1)%3 == 0){
                printf(" |");
            }
        }
        if((i+1)%3 == 0){
            printf("\n+-------+-------+-------+");
        }
    }
    printf("\n\n");
}

void hesapla(int sudoku[9][9])
{
    int i, j, a, b, m, n;
    int sayi, sayac, rakam;
    bool durum;
    struct nokta dot;

    flag:

    for(rakam = 1; rakam <= 9; rakam++){
        for(sayac = 0; sayac < 9; sayac++){
            sayi = 0;
            m = sayac - (sayac%3);
            for(i = m; i < m + 3; i++){
                n = (sayac%3) * 3;
                for(j = n; j < n + 3; j++){
                    ///****************///
                    if(sudoku[i][j] == NULL){
                        durum = true;
                        for(a = 0; a < 9; a++){
                            if(sudoku[i][a] == rakam){
                                durum = false;
                                break;
                            }
                        }
                        for(a = 0; a < 9; a++){
                            if(sudoku[a][j] == rakam){
                                durum = false;
                                break;
                            }
                        }
                        for(a = m; a < m + 3; a++){
                            for(b = n; b < n + 3; b++){
                                if(sudoku[a][b] == rakam){
                                    durum = false;
                                    break;
                                }
                            }
                        }
                        if(durum == true){
                            sayi++;
                            if(sayi == 1){
                                dot.x = i;
                                dot.y = j;
                            }
                        }
                    }
                    ///****************///
                }
            }
            if(sayi == 1){
                sudoku[dot.x][dot.y] = rakam;
            }
        }
    }

    durum = true;
    for(i = 0; i < 9; i++){
        for(j = 0; j < 9; j++){
            if(sudoku[i][j] == NULL){
                durum = false;
            }
        }
    }
    if(durum == true){
        goto son;
    }
    sudoku_yazdir(sudoku);

    goto flag;
    son:
    sudoku_yazdir(sudoku);
}
