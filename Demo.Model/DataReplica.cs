namespace Demo.Model
{
    public class DataReplica
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CutName { get; set; }

        public string SimpleName { get; set; }

        public string Category { get; set; }

        public string Displacement { get; set; }

        public string Years { get; set; }

        public int IsDel { get; set; }

        public int Status { get; set; }

        public bool IsSendToLocal { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
