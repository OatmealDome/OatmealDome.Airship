using System.Reflection;
using DotNext;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Request;

public abstract class ATQueryRequest : ATRequest
{
    protected class ATQueryRequestParameterName : Attribute
    {
        public string ParameterName
        {
            get;
            private set;
        }

        public ATQueryRequestParameterName(string parameterName)
        {
            ParameterName = parameterName;
        }
    }
    
    public override HttpMethod Method => HttpMethod.Get;

    public override HttpContent? CreateHttpContent()
    {
        return null;
    }

    public override FormUrlEncodedContent? CreateFormUrlEncodedContent()
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        
        foreach (PropertyInfo propertyInfo in this.GetType().GetProperties()
                     .Where(prop => prop.IsDefined(typeof(ATQueryRequestParameterName), false)))
        {
            object? value = propertyInfo.GetValue(this);
            
            string stringVal;

            if (value != null)
            {
                if (value.GetType().IsOptional())
                {
                    dynamic optional = value;

                    if (optional.IsUndefined)
                    {
                        continue;
                    }
                    
                    if (optional.IsNull)
                    {
                        stringVal = "null";
                    }
                    else
                    {
                        stringVal = value.ToString()!;
                    }
                }
                else
                {
                    stringVal = value.ToString()!;
                }
            }
            else
            {
                stringVal = "null";
            }
            
            ATQueryRequestParameterName attribute = propertyInfo.GetCustomAttribute<ATQueryRequestParameterName>()!;

            parameters[attribute.ParameterName] = stringVal;
        }
        
        return new FormUrlEncodedContent(parameters);
    }
}