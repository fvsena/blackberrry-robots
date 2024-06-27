namespace Blackberry.Robots.Ifood.Result
{
    public abstract class BaseResult
    {
        public bool ProcessOk { get; set; }
        public string MsgError { get; set; }
        public string MsgCatch { get; set; }
    }
}
