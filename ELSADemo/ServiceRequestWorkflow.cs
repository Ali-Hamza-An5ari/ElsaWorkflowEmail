// using Elsa.Activities.Console;
// using Elsa.Activities.Email;
// using Elsa.Activities.Primitives;
// using Elsa.Activities.Workflows;
// using Elsa.Builders;
// using Elsa.Expressions;
// using Elsa.Scripting.JavaScript;
// using Elsa.Services;
// using Elsa.Services.Models;
//
// namespace ELSADemo
// {
//     public class ServiceRequestWorkflow : IWorkflow
//     {
//         public void Build(IWorkflowBuilder builder)
//         {
//             builder
//                 .StartWith<ReceiveHttpRequest>(setup =>
//                 {
//                     setup.Path = "/submit-request";
//                 })
//                 .Then<SendEmail>(email =>
//                 {
//                     email.ToExpression = new JavaScriptExpression<string>("request.Body.Email");
//                     email.SubjectExpression = new LiteralExpression("Service Request Submitted");
//                     email.BodyExpression = new LiteralExpression("Thank you for submitting your service request. We will review it shortly.");
//                 })
//                 .Then<SendEmail>(email =>
//                 {
//                     email.ToExpression = new LiteralExpression("technician@example.com");
//                     email.SubjectExpression = new LiteralExpression("New Service Request");
//                     email.BodyExpression = new LiteralExpression("A new service request has been submitted. Please review it and take appropriate action.");
//                 })
//                 .Then<ReceiveHttpRequest>(setup =>
//                 {
//                     setup.Path = "/complete-workorder";
//                 })
//                 .Then<SetVariable>(vars =>
//                 {
//                     vars.VariableName = "status";
//                     vars.ValueExpression = new LiteralExpression("Complete");
//                 })
//                 .Then<SendEmail>(email =>
//                 {
//                     email.ToExpression = new JavaScriptExpression<string>("request.Body.Email");
//                     email.SubjectExpression = new LiteralExpression("Service Request Completed");
//                     email.BodyExpression = new LiteralExpression("Your service request has been completed. Thank you for using our services.");
//                 });
//         }
//     }
//
// }
