//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Core.Config
{
    
    
    /// <summary>
    /// The CalculateSettings Configuration Section.
    /// </summary>
    public partial class CalculateSettings : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the CalculateSettings Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string CalculateSettingsSectionName = "calculateSettings";
        
        /// <summary>
        /// Gets the CalculateSettings instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public static global::Infrastructure.Core.Config.CalculateSettings Instance
        {
            get
            {
                return ((global::Infrastructure.Core.Config.CalculateSettings)(global::System.Configuration.ConfigurationManager.GetSection(global::Infrastructure.Core.Config.CalculateSettings.CalculateSettingsSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Infrastructure.Core.Config.CalculateSettings.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Infrastructure.Core.Config.CalculateSettings.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region DispatcherDefaultInterval Property
        /// <summary>
        /// The XML name of the <see cref="DispatcherDefaultInterval"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string DispatcherDefaultIntervalPropertyName = "dispatcherDefaultInterval";
        
        /// <summary>
        /// Gets or sets the DispatcherDefaultInterval.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The DispatcherDefaultInterval.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Infrastructure.Core.Config.CalculateSettings.DispatcherDefaultIntervalPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual int DispatcherDefaultInterval
        {
            get
            {
                return ((int)(base[global::Infrastructure.Core.Config.CalculateSettings.DispatcherDefaultIntervalPropertyName]));
            }
            set
            {
                base[global::Infrastructure.Core.Config.CalculateSettings.DispatcherDefaultIntervalPropertyName] = value;
            }
        }
        #endregion
        
        #region DispatcherDefaultProtectedDay Property
        /// <summary>
        /// The XML name of the <see cref="DispatcherDefaultProtectedDay"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string DispatcherDefaultProtectedDayPropertyName = "dispatcherDefaultProtectedDay";
        
        /// <summary>
        /// Gets or sets the DispatcherDefaultProtectedDay.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The DispatcherDefaultProtectedDay.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Infrastructure.Core.Config.CalculateSettings.DispatcherDefaultProtectedDayPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual int DispatcherDefaultProtectedDay
        {
            get
            {
                return ((int)(base[global::Infrastructure.Core.Config.CalculateSettings.DispatcherDefaultProtectedDayPropertyName]));
            }
            set
            {
                base[global::Infrastructure.Core.Config.CalculateSettings.DispatcherDefaultProtectedDayPropertyName] = value;
            }
        }
        #endregion
        
        #region IsQueryLocalOnly Property
        /// <summary>
        /// The XML name of the <see cref="IsQueryLocalOnly"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string IsQueryLocalOnlyPropertyName = "isQueryLocalOnly";
        
        /// <summary>
        /// Gets or sets the IsQueryLocalOnly.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The IsQueryLocalOnly.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Infrastructure.Core.Config.CalculateSettings.IsQueryLocalOnlyPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual bool IsQueryLocalOnly
        {
            get
            {
                return ((bool)(base[global::Infrastructure.Core.Config.CalculateSettings.IsQueryLocalOnlyPropertyName]));
            }
            set
            {
                base[global::Infrastructure.Core.Config.CalculateSettings.IsQueryLocalOnlyPropertyName] = value;
            }
        }
        #endregion
        
        #region EffectiveAirlineUrl Property
        /// <summary>
        /// The XML name of the <see cref="EffectiveAirlineUrl"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string EffectiveAirlineUrlPropertyName = "effectiveAirlineUrl";
        
        /// <summary>
        /// Gets or sets the EffectiveAirlineUrl.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The EffectiveAirlineUrl.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Infrastructure.Core.Config.CalculateSettings.EffectiveAirlineUrlPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string EffectiveAirlineUrl
        {
            get
            {
                return ((string)(base[global::Infrastructure.Core.Config.CalculateSettings.EffectiveAirlineUrlPropertyName]));
            }
            set
            {
                base[global::Infrastructure.Core.Config.CalculateSettings.EffectiveAirlineUrlPropertyName] = value;
            }
        }
        #endregion
        
        #region FlightConditionIntervalStrategyName Property
        /// <summary>
        /// The XML name of the <see cref="FlightConditionIntervalStrategyName"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string FlightConditionIntervalStrategyNamePropertyName = "flightConditionIntervalStrategyName";
        
        /// <summary>
        /// Gets or sets the FlightConditionIntervalStrategyName.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The FlightConditionIntervalStrategyName.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Infrastructure.Core.Config.CalculateSettings.FlightConditionIntervalStrategyNamePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string FlightConditionIntervalStrategyName
        {
            get
            {
                return ((string)(base[global::Infrastructure.Core.Config.CalculateSettings.FlightConditionIntervalStrategyNamePropertyName]));
            }
            set
            {
                base[global::Infrastructure.Core.Config.CalculateSettings.FlightConditionIntervalStrategyNamePropertyName] = value;
            }
        }
        #endregion
        
        #region ProviderSettings Property
        /// <summary>
        /// The XML name of the <see cref="ProviderSettings"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string ProviderSettingsPropertyName = "providerSettings";
        
        /// <summary>
        /// Gets or sets the ProviderSettings.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The ProviderSettings.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Infrastructure.Core.Config.CalculateSettings.ProviderSettingsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Infrastructure.Core.Config.ProviderSettings ProviderSettings
        {
            get
            {
                return ((global::Infrastructure.Core.Config.ProviderSettings)(base[global::Infrastructure.Core.Config.CalculateSettings.ProviderSettingsPropertyName]));
            }
            set
            {
                base[global::Infrastructure.Core.Config.CalculateSettings.ProviderSettingsPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Infrastructure.Core.Config
{
    
    
    /// <summary>
    /// The ProviderSettings Configuration Element.
    /// </summary>
    public partial class ProviderSettings : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region ProviderSetting Property
        /// <summary>
        /// The XML name of the <see cref="ProviderSetting"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string ProviderSettingPropertyName = "providerSetting";
        
        /// <summary>
        /// Gets or sets the ProviderSetting.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The ProviderSetting.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Infrastructure.Core.Config.ProviderSettings.ProviderSettingPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Infrastructure.Core.Config.ProviderSetting ProviderSetting
        {
            get
            {
                return ((global::Infrastructure.Core.Config.ProviderSetting)(base[global::Infrastructure.Core.Config.ProviderSettings.ProviderSettingPropertyName]));
            }
            set
            {
                base[global::Infrastructure.Core.Config.ProviderSettings.ProviderSettingPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Infrastructure.Core.Config
{
    
    
    /// <summary>
    /// The ProviderSetting Configuration Element.
    /// </summary>
    public partial class ProviderSetting : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}