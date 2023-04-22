﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipesApp.CreateRecipeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ingredient", Namespace="http://schemas.datacontract.org/2004/07/WSDL_Services")]
    [System.SerializableAttribute()]
    public partial class Ingredient : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CreateRecipeService.ICreateRecipeService")]
    public interface ICreateRecipeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateRecipeService/SearchProducts", ReplyAction="http://tempuri.org/ICreateRecipeService/SearchProductsResponse")]
        RecipesApp.CreateRecipeService.Ingredient[] SearchProducts(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateRecipeService/SearchProducts", ReplyAction="http://tempuri.org/ICreateRecipeService/SearchProductsResponse")]
        System.Threading.Tasks.Task<RecipesApp.CreateRecipeService.Ingredient[]> SearchProductsAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateRecipeService/AddToRecipe", ReplyAction="http://tempuri.org/ICreateRecipeService/AddToRecipeResponse")]
        void AddToRecipe(string fileName, int productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateRecipeService/AddToRecipe", ReplyAction="http://tempuri.org/ICreateRecipeService/AddToRecipeResponse")]
        System.Threading.Tasks.Task AddToRecipeAsync(string fileName, int productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateRecipeService/GetCreatedRecipes", ReplyAction="http://tempuri.org/ICreateRecipeService/GetCreatedRecipesResponse")]
        RecipesApp.CreateRecipeService.Ingredient[] GetCreatedRecipes(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateRecipeService/GetCreatedRecipes", ReplyAction="http://tempuri.org/ICreateRecipeService/GetCreatedRecipesResponse")]
        System.Threading.Tasks.Task<RecipesApp.CreateRecipeService.Ingredient[]> GetCreatedRecipesAsync(string fileName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreateRecipeServiceChannel : RecipesApp.CreateRecipeService.ICreateRecipeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateRecipeServiceClient : System.ServiceModel.ClientBase<RecipesApp.CreateRecipeService.ICreateRecipeService>, RecipesApp.CreateRecipeService.ICreateRecipeService {
        
        public CreateRecipeServiceClient() {
        }
        
        public CreateRecipeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreateRecipeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateRecipeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateRecipeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RecipesApp.CreateRecipeService.Ingredient[] SearchProducts(string query) {
            return base.Channel.SearchProducts(query);
        }
        
        public System.Threading.Tasks.Task<RecipesApp.CreateRecipeService.Ingredient[]> SearchProductsAsync(string query) {
            return base.Channel.SearchProductsAsync(query);
        }
        
        public void AddToRecipe(string fileName, int productId) {
            base.Channel.AddToRecipe(fileName, productId);
        }
        
        public System.Threading.Tasks.Task AddToRecipeAsync(string fileName, int productId) {
            return base.Channel.AddToRecipeAsync(fileName, productId);
        }
        
        public RecipesApp.CreateRecipeService.Ingredient[] GetCreatedRecipes(string fileName) {
            return base.Channel.GetCreatedRecipes(fileName);
        }
        
        public System.Threading.Tasks.Task<RecipesApp.CreateRecipeService.Ingredient[]> GetCreatedRecipesAsync(string fileName) {
            return base.Channel.GetCreatedRecipesAsync(fileName);
        }
    }
}
