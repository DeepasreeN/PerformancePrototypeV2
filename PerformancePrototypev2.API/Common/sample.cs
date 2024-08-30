namespace PerformancePrototypev2.API.Common
{
    public interface Isample
    {
        protected void getdata();
        internal void getdata1();
    }

    public class Sample : Isample
    {
        void Isample.getdata()
        {
            throw new NotImplementedException();
        }

        void Isample.getdata1()
        {
            throw new NotImplementedException();
        }
    }
}
