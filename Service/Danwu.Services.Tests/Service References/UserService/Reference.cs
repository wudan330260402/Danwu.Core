﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Danwu.Services.Tests.UserService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDto", Namespace="http://schemas.datacontract.org/2004/07/Danwu.Application.DTO.System")]
    [System.SerializableAttribute()]
    public partial class UserDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastLogonTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NickNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassWordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RealNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime RegisterTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastLogonTime {
            get {
                return this.LastLogonTimeField;
            }
            set {
                if ((this.LastLogonTimeField.Equals(value) != true)) {
                    this.LastLogonTimeField = value;
                    this.RaisePropertyChanged("LastLogonTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NickName {
            get {
                return this.NickNameField;
            }
            set {
                if ((object.ReferenceEquals(this.NickNameField, value) != true)) {
                    this.NickNameField = value;
                    this.RaisePropertyChanged("NickName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PassWord {
            get {
                return this.PassWordField;
            }
            set {
                if ((object.ReferenceEquals(this.PassWordField, value) != true)) {
                    this.PassWordField = value;
                    this.RaisePropertyChanged("PassWord");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PhoneNo {
            get {
                return this.PhoneNoField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneNoField, value) != true)) {
                    this.PhoneNoField = value;
                    this.RaisePropertyChanged("PhoneNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RealName {
            get {
                return this.RealNameField;
            }
            set {
                if ((object.ReferenceEquals(this.RealNameField, value) != true)) {
                    this.RealNameField = value;
                    this.RaisePropertyChanged("RealName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime RegisterTime {
            get {
                return this.RegisterTimeField;
            }
            set {
                if ((this.RegisterTimeField.Equals(value) != true)) {
                    this.RegisterTimeField = value;
                    this.RaisePropertyChanged("RegisterTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int State {
            get {
                return this.StateField;
            }
            set {
                if ((this.StateField.Equals(value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CreateUser", ReplyAction="http://tempuri.org/IUserService/CreateUserResponse")]
        bool CreateUser(Danwu.Services.Tests.UserService.UserDto userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CreateUser", ReplyAction="http://tempuri.org/IUserService/CreateUserResponse")]
        System.Threading.Tasks.Task<bool> CreateUserAsync(Danwu.Services.Tests.UserService.UserDto userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        bool UpdateUser(Danwu.Services.Tests.UserService.UserDto userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(Danwu.Services.Tests.UserService.UserDto userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        bool DeleteUser(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        System.Threading.Tasks.Task<bool> DeleteUserAsync(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        Danwu.Services.Tests.UserService.UserDto GetUser(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        System.Threading.Tasks.Task<Danwu.Services.Tests.UserService.UserDto> GetUserAsync(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/QueryAll", ReplyAction="http://tempuri.org/IUserService/QueryAllResponse")]
        Danwu.Services.Tests.UserService.UserDto[] QueryAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/QueryAll", ReplyAction="http://tempuri.org/IUserService/QueryAllResponse")]
        System.Threading.Tasks.Task<Danwu.Services.Tests.UserService.UserDto[]> QueryAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : Danwu.Services.Tests.UserService.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<Danwu.Services.Tests.UserService.IUserService>, Danwu.Services.Tests.UserService.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateUser(Danwu.Services.Tests.UserService.UserDto userDto) {
            return base.Channel.CreateUser(userDto);
        }
        
        public System.Threading.Tasks.Task<bool> CreateUserAsync(Danwu.Services.Tests.UserService.UserDto userDto) {
            return base.Channel.CreateUserAsync(userDto);
        }
        
        public bool UpdateUser(Danwu.Services.Tests.UserService.UserDto userDto) {
            return base.Channel.UpdateUser(userDto);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserAsync(Danwu.Services.Tests.UserService.UserDto userDto) {
            return base.Channel.UpdateUserAsync(userDto);
        }
        
        public bool DeleteUser(string userId) {
            return base.Channel.DeleteUser(userId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteUserAsync(string userId) {
            return base.Channel.DeleteUserAsync(userId);
        }
        
        public Danwu.Services.Tests.UserService.UserDto GetUser(string userId) {
            return base.Channel.GetUser(userId);
        }
        
        public System.Threading.Tasks.Task<Danwu.Services.Tests.UserService.UserDto> GetUserAsync(string userId) {
            return base.Channel.GetUserAsync(userId);
        }
        
        public Danwu.Services.Tests.UserService.UserDto[] QueryAll() {
            return base.Channel.QueryAll();
        }
        
        public System.Threading.Tasks.Task<Danwu.Services.Tests.UserService.UserDto[]> QueryAllAsync() {
            return base.Channel.QueryAllAsync();
        }
    }
}
