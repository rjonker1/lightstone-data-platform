
namespace Toolbox.Emailing.Domain
{
    public abstract class AbstractEmailMessageBuilder<Template> : IBuildEmailMessage<Template>
    {

        public virtual string TemplateName { get; }
        public virtual string CcAddress { get; }
        public virtual string BccAddress { get; }
        public virtual string Address { get; }
        public virtual string Subject { get; }
        public virtual string Body { get; }

        public abstract void Generate(Template template);

        public void Generate(object template)
        {
            Generate((Template) template);
        }
    }
}
