namespace ShearwaterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dive1 = new DiveManifest("A5-C4-00-0C-5B-59-98-67-5B-59-98-84-00-00-00-1D-00-86-00-55-00-06-61-00-00-06-63-A0-01-03-06-01", 28);
            dive1.GetDiveDetails();
            var dive2 = new DiveManifest("A5-C4-00-0B-5B-1C-E8-B8-5B-1C-FF-91-00-00-16-D9-07-2B-02-E5-00-05-60-20-00-05-AD-60-01-03-00-01", 28);
            dive2.GetDiveDetails(); 
            var dive3 = new DiveManifest("5A-23-00-0A-5B-1B-96-DD-5B-1B-AC-A1-00-00-15-C4-05-EC-02-DB-00-05-0E-80-00-05-56-80-01-03-00-01", 28);
            dive3.GetDiveDetails();
            var dive4 = new DiveManifest("A5-C4-00-09-5B-1A-55-5F-5B-1A-6A-A0-00-00-15-41-07-C0-02-F6-00-04-B8-80-00-05-00-80-01-03-00-01", 28);
            dive4.GetDiveDetails();
        }
    }
}
