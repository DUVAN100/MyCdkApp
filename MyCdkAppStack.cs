using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.IAM;
using System.Collections.Generic;
using Constructs;

namespace MyCdkApp
{
    public class MyCdkAppStack : Stack
    {
        internal MyCdkAppStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            //create lambda function
            var lambdaFunction = new Function(this, "MyPythonLambda",
                new FunctionProps
                {
                    Runtime = Runtime.PYTHON_3_10,
                    Handler = "app.lambda_handler",
                    Code = Code.FromAsset("../lambda"),  // Directory code lambda
                    Environment = new Dictionary<string, string>
                    {
                        { "ENV_VAR_EXAMPLE", "value" }
                    }
                });

            // Permisos básicos para la Lambda
            lambdaFunction.Role?.AddManagedPolicy(
                ManagedPolicy.FromAwsManagedPolicyName("service-role/AWSLambdaBasicExecutionRole"));
        }
    }
}
