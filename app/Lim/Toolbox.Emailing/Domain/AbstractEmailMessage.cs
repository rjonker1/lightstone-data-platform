
namespace Toolbox.Emailing.Domain
{
    public abstract class AbstractEmailMessageBuilder<Template> : IBuildEmailMessage<Template>
    {

        public virtual string TemplateName { get; private set; }
        public virtual string CcAddress { get; private set; }
        public virtual string BccAddress { get; private set; }
        public virtual string Address { get; private set; }
        public virtual string Subject { get; private set; }
        public virtual string Body { get; private set; }

        public abstract void Generate(Template template);

        public void Generate(object template)
        {
            Generate((Template) template);
        }
    }
}
