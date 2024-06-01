using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

public class Result
{
    public Biodata biodata;
    public Bitmap picture;
    public float similarity;
    public float executionTime;

    public Result(Biodata biodata, Bitmap picture, float similarity, float executionTime) {
        this.biodata = biodata;
        this.picture = picture;
        this.similarity = similarity;
        this.executionTime = executionTime;
    }
}
