﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------



<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
System.ServiceModel.ServiceContractAttribute(Namespace:="http://Microsoft.WCF.Documentation", _
                                             ConfigurationName:="ISampleService")> _
Public Interface ISampleService

    <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.WCF.Documentation/OperationContractMethod", _
                                ReplyAction:="http://Microsoft.WCF.Documentation/ResponseToOCAMethod")> _
    Function OCAMethod(ByVal msg As String) As String
End Interface

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
Public Interface ISampleServiceChannel
	Inherits ISampleService, System.ServiceModel.IClientChannel
End Interface

<DebuggerStepThroughAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
Partial Public Class SampleServiceClient
	Inherits System.ServiceModel.ClientBase(Of ISampleService)
	Implements ISampleService

	Public Sub New()
	End Sub

	Public Sub New(ByVal endpointConfigurationName As String)
		MyBase.New(endpointConfigurationName)
	End Sub

	Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
		MyBase.New(endpointConfigurationName, remoteAddress)
	End Sub

	Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
		MyBase.New(endpointConfigurationName, remoteAddress)
	End Sub

	Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
		MyBase.New(binding, remoteAddress)
	End Sub

	Public Function OCAMethod(ByVal msg As String) As String Implements ISampleService.OCAMethod
		Return MyBase.Channel.OCAMethod(msg)
	End Function
End Class
