package humancentricplag;

public class TokenTuple {
	public String content, type;
        public int index,line;
        
	public TokenTuple(String content, String type, int index, int line) {
		super();
		this.content = content;
		this.type = type;
                this.index=index;
                this.line=line;
	}
	
	public String toString(){
		return content;// + " | " + type;
	}
        public int getIndex(){
            return index;
        }
        public int getLine(){
            return line;
        }
}
