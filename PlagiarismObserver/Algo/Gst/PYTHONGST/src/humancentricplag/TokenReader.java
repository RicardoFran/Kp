package humancentricplag;

import java.util.ArrayList;
import java.util.List;

import org.antlr.v4.runtime.ANTLRFileStream;
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.Token;

import pythonantlr.Python3Lexer;

public class TokenReader {
	/*
	 * accept a path and then generate token stream from that file. It is
	 * important to note that this method only works iff ANTLR has been
	 * installed as an external JAR
	 */
	public static ArrayList<TokenTuple> generateTokenStream(String filePath) {
		ArrayList<TokenTuple> result = null;
		try {
			// ANTLR code to read tokens
			Lexer lexer = new Python3Lexer(new ANTLRFileStream(filePath));
                        
			List<Token> tokens = (List<Token>) lexer.getAllTokens();
			// create a list to store the result
                        result = new ArrayList<TokenTuple>();
			// copy each token to result
			for (int i = 0; i < tokens.size(); i++) {
				TokenTuple t = new TokenTuple(tokens.get(i).getText(),
						Python3Lexer.VOCABULARY.getDisplayName(tokens.get(i).getType()),tokens.get(i).getLine(),tokens.get(i).getCharPositionInLine());
				result.add(t);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		// return the result. Obvious, isn't it?
		return result;
	}
	// public static get
}
