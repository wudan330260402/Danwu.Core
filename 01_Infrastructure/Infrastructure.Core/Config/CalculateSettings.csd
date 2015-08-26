<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="699d3e61-1798-465e-b282-5a004a096612" namespace="Infrastructure.Core.Config" xmlSchemaNamespace="urn:Infrastructure.Core.Config" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="CalculateSettings" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="calculateSettings">
      <attributeProperties>
        <attributeProperty name="DispatcherDefaultInterval" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="dispatcherDefaultInterval" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/699d3e61-1798-465e-b282-5a004a096612/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="DispatcherDefaultProtectedDay" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="dispatcherDefaultProtectedDay" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/699d3e61-1798-465e-b282-5a004a096612/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="IsQueryLocalOnly" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="isQueryLocalOnly" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/699d3e61-1798-465e-b282-5a004a096612/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="EffectiveAirlineUrl" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="effectiveAirlineUrl" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/699d3e61-1798-465e-b282-5a004a096612/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="FlightConditionIntervalStrategyName" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="flightConditionIntervalStrategyName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/699d3e61-1798-465e-b282-5a004a096612/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="ProviderSettings" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="providerSettings" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/699d3e61-1798-465e-b282-5a004a096612/ProviderSettings" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="ProviderSettings">
      <elementProperties>
        <elementProperty name="ProviderSetting" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="providerSetting" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/699d3e61-1798-465e-b282-5a004a096612/ProviderSetting" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="ProviderSetting" />
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>