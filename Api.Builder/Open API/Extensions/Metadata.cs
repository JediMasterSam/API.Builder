using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public static class Metadata
    {
        private static MetadataReader<ApiVersion> ApiVersionReader { get; set; } = new ApiVersionReader();
        
        private static MetadataReader<BindingSource> BindingSourceReader { get; set; } = new BindingSourceReader();
        
        private static MetadataReader<object> DefaultValueReader { get; set; } = new DefaultValueReader();
        
        private static MetadataReader<bool> DeprecatedReader { get; set; } = new DeprecatedReader();
        
        private static MetadataReader<string> DescriptionReader { get; set; } = new DescriptionReader();
        
        private static MetadataReader<Type> ElementTypeReader { get; set; } = new ElementTypeReader();
        
        private static MetadataReader<IEnumerable<FieldInfo>> FieldReader { get; set; } = new FieldReader();
        
        private static MetadataReader<bool> IgnoredReader { get; set; } = new IgnoredReader();
        
        private static MetadataReader<IConvertible> MaximumReader { get; set; } = new MaximumReader();
        
        private static MetadataReader<IEnumerable<MethodInfo>> MethodReader { get; set; } = new MethodReader();
        
        private static MetadataReader<IConvertible> MinimumReader { get; set; } = new MinimumReader();
        
        private static MetadataReader<string> NameReader { get; set; } = new NameReader();
        
        private static MetadataReader<bool> ObsoleteReader { get; set; } = new ObsoleteReader();
        
        private static MetadataReader<OperationType> OperationTypeReader { get; set; } = new OperationTypeReader();
        
        private static MetadataReader<IEnumerable<PropertyInfo>> PropertyReader { get; set; } = new PropertyReader();
        
        private static MetadataReader<bool> RequiredReader { get; set; } = new RequiredReader();
        
        private static MetadataReader<IEnumerable<ApiResponseType>> ResponseReader { get; set; } = new ResponseReader();
        
        private static MetadataReader<Type> TypeReader { get; set; } = new TypeReader();
        
        private static MetadataReader<Type> UnderlyingTypeReader { get; set; } = new UnderlyingTypeReader();
        
        public static ApiVersion ApiVersion<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return ApiVersionReader.GetFromProvider(provider);
        }
        
        public static BindingSource BindingSource<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return BindingSourceReader.GetFromProvider(provider);
        }
        
        public static object DefaultValue<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return DefaultValueReader.GetFromProvider(provider);
        }
        
        public static bool Deprecated<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return DeprecatedReader.GetFromProvider(provider);
        }

        public static string Description<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return DescriptionReader.GetFromProvider(provider);
        }
        
        public static Type ElementType<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return ElementTypeReader.GetFromProvider(provider);
        }
        
        public static IEnumerable<FieldInfo> Fields<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return FieldReader.GetFromProvider(provider);
        }
        
        public static bool Ignored<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return IgnoredReader.GetFromProvider(provider);
        }
        
        public static IConvertible Maximum<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return MaximumReader.GetFromProvider(provider);
        }
        
        public static IEnumerable<MethodInfo> Methods<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return MethodReader.GetFromProvider(provider);
        }
        
        public static IConvertible Minimum<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return MinimumReader.GetFromProvider(provider);
        }
        
        public static string Name<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return NameReader.GetFromProvider(provider);
        }
        
        public static bool Obsolete<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return ObsoleteReader.GetFromProvider(provider);
        }

        public static OperationType OperationType<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return OperationTypeReader.GetFromProvider(provider);
        }

        public static IEnumerable<PropertyInfo> Properties<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return PropertyReader.GetFromProvider(provider);
        }
        
        public static bool Required<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return RequiredReader.GetFromProvider(provider);
        }
        
        public static IEnumerable<ApiResponseType> Responses<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return ResponseReader.GetFromProvider(provider);
        }
        
        public static Type Type<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return TypeReader.GetFromProvider(provider);
        }
        
        public static Type UnderlyingType<TProvider>(this TProvider provider) where TProvider : ICustomAttributeProvider
        {
            return UnderlyingTypeReader.GetFromProvider(provider);
        }

        public static void SetApiVersionReader<TReader>() where TReader : MetadataReader<ApiVersion>, new()
        {
            ApiVersionReader = new TReader();
        }

        public static void SetBindingSourceReader<TReader>() where TReader : MetadataReader<BindingSource>, new()
        {
            BindingSourceReader = new TReader();
        }

        public static void SetDefaultValueReader<TReader>() where TReader : MetadataReader<object>, new()
        {
            DefaultValueReader = new TReader();
        }

        public static void SetDeprecatedReader<TReader>() where TReader : MetadataReader<bool>, new()
        {
            DeprecatedReader = new TReader();
        }

        public static void SetDescriptionReader<TReader>() where TReader : MetadataReader<string>, new()
        {
            DescriptionReader = new TReader();
        }

        public static void SetElementTypeReader<TReader>() where TReader : MetadataReader<Type>, new()
        {
            ElementTypeReader = new TReader();
        }

        public static void SetFieldReader<TReader>() where TReader : MetadataReader<IEnumerable<FieldInfo>>, new()
        {
            FieldReader = new TReader();
        }

        public static void SetIgnoredReader<TReader>() where TReader : MetadataReader<bool>, new()
        {
            IgnoredReader = new TReader();
        }

        public static void SetMaximumReader<TReader>() where TReader : MetadataReader<IConvertible>, new()
        {
            MaximumReader = new TReader();
        }

        public static void SetMethodReader<TReader>() where TReader : MetadataReader<IEnumerable<MethodInfo>>, new()
        {
            MethodReader = new TReader();
        }

        public static void SetMinimumReader<TReader>() where TReader : MetadataReader<IConvertible>, new()
        {
            MinimumReader = new TReader();
        }

        public static void SetNameReader<TReader>() where TReader : MetadataReader<string>, new()
        {
            NameReader = new TReader();
        }

        public static void SetObsoleteReader<TReader>() where TReader : MetadataReader<bool>, new()
        {
            ObsoleteReader = new TReader();
        }
        
        public static void SetOperationTypeReader<TReader>() where TReader : MetadataReader<OperationType>, new()
        {
            OperationTypeReader = new TReader();
        }
        
        public static void SetPropertyReader<TReader>() where TReader : MetadataReader<IEnumerable<PropertyInfo>>, new()
        {
            PropertyReader = new TReader();
        }

        public static void SetRequiredReader<TReader>() where TReader : MetadataReader<bool>, new()
        {
            RequiredReader = new TReader();
        }

        public static void SetResponseReader<TReader>() where TReader : MetadataReader<IEnumerable<ApiResponseType>>, new()
        {
            ResponseReader = new TReader();
        }

        public static void SetTypeReader<TReader>() where TReader : MetadataReader<Type>, new()
        {
            TypeReader = new TReader();
        }

        public static void SetUnderlyingTypeReader<TReader>() where TReader : MetadataReader<Type>, new()
        {
            UnderlyingTypeReader = new TReader();
        }
    }
}