namespace Toolbox.Emailing.Domain
{
    public interface IBuildEmailMessage
    {
        string TemplateName { get; }
        string CcAddress { get; }
        string BccAddress { get; }
        string Address { get; }
        string Subject { get; }
        string Body { get; }
        void Generate(object template);
    }

    public interface IBuildEmailMessage<in Template> : IBuildEmailMessage
    {
        void Generate(Template template);
    }
}
