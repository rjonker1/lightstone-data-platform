namespace Workflow.Lace.Messages.Core
{
    public interface ISendCommandToBus
    {
        ISendWorkflowCommand Workflow { get; }
    }
}
