using System.ServiceModel;

namespace MyMathServiceLib
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        int Add(int num1, int num2);

        [OperationContract]
        int Subtract(int num1, int num2);

        [OperationContract]
        int Multiply(int num1, int num2);

        [OperationContract]
        int Divide(int num1, int num2);
    }
}
