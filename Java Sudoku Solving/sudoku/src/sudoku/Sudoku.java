/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package sudoku;
import java.util.*;
import java.io.*;
/**
 *
 * @author ILYAS MAMMADOV
 */
public class Sudoku {
    

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        int [][]sudoku = new int[9][9];
        int i, j;
        for(i = 0; i < 9; i++){
            for(j = 0; j < 9; j++){
                sudoku[i][j] = 0;
            }
        }
        
        //degiskenler........
        int c;
        
        File dosya = new File("ornek1/sudoku.txt");
        if(!dosya.exists()){
            System.out.println("Dosya açılamadı!");
        }
        else{
            FileInputStream ch = new FileInputStream(dosya);
            
            for(i = 0; i < 9; i++){
                for(j = 0; j < 9; j++){
                    c = ch.read();
                    if(c != '*'){
                        sudoku[i][j] = Character.getNumericValue(c);
                    }
                }
                c = ch.read();
                c = ch.read();
            }
            ch.close();
            
            sudoku_yazdir(sudoku);
            sudoku_hesapla(sudoku);
        }
    }
    
    public static void sudoku_yazdir(int [][]sudoku)
    {
        
    int i, j;

    System.out.print("+-------+-------+-------+");
    for(i = 0; i < 9; i++){
        System.out.print("\n|");
        for(j = 0; j < 9; j ++){
            if(sudoku[i][j] != 0){
                System.out.print(" " + sudoku[i][j]);
            }
            else{
                System.out.print("  ");
            }
            if((j+1)%3 == 0){
                System.out.print(" |");
            }
        }
        if((i+1)%3 == 0){
            System.out.print("\n+-------+-------+-------+");
        }
    }
    System.out.println("\n");
    }
    
    public static void sudoku_hesapla(int [][]sudoku){
        int i, j, a, b, m, n;
        int sayi, sayac, rakam;
        boolean durum = false;
        Nokta nokta = new Nokta();

        while(durum == false){
            for(rakam = 1; rakam <= 9; rakam++){
                for(sayac = 0; sayac < 9; sayac++){
                    sayi = 0;
                    m = sayac - (sayac%3);
                    for(i = m; i < m + 3; i++){
                        n = (sayac%3) * 3;
                        for(j = n; j < n + 3; j++){
                            ///****************///
                            if(sudoku[i][j] == 0){
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
                                        nokta.x = i;
                                        nokta.y = j;
                                    }
                                }
                            }
                            ///****************///
                        }
                    }
                    if(sayi == 1){
                        sudoku[nokta.x][nokta.y] = rakam;
                    }
                }
            }

            durum = true;
            for(i = 0; i < 9; i++){
                for(j = 0; j < 9; j++){
                    if(sudoku[i][j] == 0){
                        durum = false;
                    }
                }
            }
        }
        sudoku_yazdir(sudoku);
    }
    
}
