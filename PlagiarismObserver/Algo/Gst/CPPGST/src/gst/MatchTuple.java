package gst;

/*
 * tuple untuk menyimpan hasil kesamaan
 */
public class MatchTuple {
	public int patternPosition;
	public int textPosition;
	public int length;
	public MatchTuple(int p, int t, int l){
		this.patternPosition = p;
		this.textPosition = t;
		this.length = l;
	}
	
	public String toString(){
		return patternPosition + ":" + textPosition + ":" + length;
	}
}
