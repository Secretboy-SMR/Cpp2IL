using LibCpp2IL;
using LibCpp2IL.Metadata;

namespace Cpp2IL.Core.Model.Contexts;

/// <summary>
/// Represents a field in a managed type.
/// </summary>
public class FieldAnalysisContext : HasCustomAttributes
{
    /// <summary>
    /// The analysis context for the type that this field belongs to.
    /// </summary>
    public readonly TypeAnalysisContext DeclaringType;
    
    /// <summary>
    /// The underlying field metadata.
    /// </summary>
    public readonly Il2CppFieldReflectionData BackingData;
    
    protected override int CustomAttributeIndex => BackingData.field.customAttributeIndex;

    protected override AssemblyAnalysisContext CustomAttributeAssembly => DeclaringType.DeclaringAssembly;

    public FieldAnalysisContext(Il2CppFieldReflectionData backingData, TypeAnalysisContext parent) : base(backingData.field.token, parent.AppContext)
    {
        DeclaringType = parent;
        BackingData = backingData;
        
        InitCustomAttributeData();
    }
}