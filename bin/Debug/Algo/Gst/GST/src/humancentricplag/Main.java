package humancentricplag;

import generatedantlrjava.Java8Lexer;
import java.util.ArrayList;
import java.util.Scanner;

import gst.GreedyStringTiling;
import gst.MatchTuple;
import java.io.IOException;
import java.util.List;
import org.antlr.v4.runtime.ANTLRFileStream;
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.Token;

public class Main {

    public static void main(String[] args) throws IOException {
        // get both Java files
        Scanner file = new Scanner(System.in);
        String filePath1 = "C:\Users\carlc\Desktop\ToDo\Testing\Group2\Person6\Sesi2\Soal1\Non-Plagiarism\Non-Plagiarism.java";
        String filePath2 = "C:\Users\carlc\Desktop\ToDo\Testing\Group2\Person6\Sesi2\Soal1\Plagiarism\Plagiarism.java";
        //String filePath1 = file.nextLine();
        //String filePath2 = file.nextLine();
        // generate token stream
        ArrayList<TokenTuple> result1 = TokenReader.generateTokenStream(filePath1);
        ArrayList<TokenTuple> result2 = TokenReader.generateTokenStream(filePath2);

        //System.out.println("Hasil tokenisasi file pertama(F1.java):");
        //System.out.println(result1 + "\n");
        //System.out.println("Hasil tokenisasi file kedua(T1.java): ");
        //System.out.println(result2 + "\n");
        // start comparing using RK-GST
        /*
		 * convert list result to object string. In fact, this part can be
		 * optimized by generating array of string directly at generateTokenStream method. 
		 * However, for reusablity purpose, it is still needed to be converted.
         */
        String[] s1 = new String[result1.size()];
        int[] indexs1 = new int[result1.size()];
        int[] lines1 = new int[result1.size()];
        for (int i = 0; i < result1.size(); i++) {
            s1[i] = result1.get(i).toString();
            indexs1[i] = result1.get(i).getIndex();
            lines1[i] = result1.get(i).getLine();
        }
        String[] s2 = new String[result2.size()];
        int[] indexs2 = new int[result2.size()];
        int[] lines2 = new int[result2.size()];
        for (int i = 0; i < result2.size(); i++) {
            s2[i] = result2.get(i).toString();
            indexs2[i] = result2.get(i).getIndex();
            lines2[i] = result2.get(i).getLine();
        }

        // get matches
        ArrayList<MatchTuple> matches = GreedyStringTiling.getMatchedTiles(s1, s2, 2);

        /*                for (String asd : s1) {
                    System.out.println(asd);
            }*/
        for (int i = 0; i < result1.size(); i++) {
            System.out.println(s1[i]);
        }
        System.out.println("=EndOfString=");
        for (int i = 0; i < result1.size(); i++) {
            System.out.println(indexs1[i]);
        }
        System.out.println("=EndOfLine=");
        for (int i = 0; i < result1.size(); i++) {
            System.out.println(lines1[i]);
        }
        System.out.println("=EndOfFile=");
        /*               for (String asd : s2) {
                    System.out.println(asd);
            }*/
        for (int i = 0; i < result2.size(); i++) {
            System.out.println(s2[i]);
        }
        System.out.println("=EndOfString=");
        for (int i = 0; i < result2.size(); i++) {
            System.out.println(indexs2[i]);
        }
        System.out.println("=EndOfLine=");
        for (int i = 0; i < result2.size(); i++) {
            System.out.println(lines2[i]);
        }
        System.out.println("=EndOfFile=");
        // show the matches
        System.out.println(matches + "\n");
    }
}
