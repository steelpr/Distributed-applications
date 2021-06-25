using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        List<ArticleDTO> GetArticle();

        [OperationContract]
        string PostArticle(ArticleDTO articleDTO);

        [OperationContract]
        ArticleDTO GetArticleById(int id);

        [OperationContract]
        string EditArticle(ArticleDTO articleDTO);


        [OperationContract]
        string DeleteArticle(int id);

        //

        [OperationContract]
        List<EventDTO> GetEvent();

        [OperationContract]
        string PostEvent(EventDTO eventDTO);

        [OperationContract]
        EventDTO GetEventById(int id);

        [OperationContract]
        string EditEvent(EventDTO eventDTO);


        [OperationContract]
        string DeleteEvent(int id);

        //
        [OperationContract]
        List<RecipeDTO> GetRecipe();

        [OperationContract]
        string PostRecipe(RecipeDTO recipeDTO);

        [OperationContract]
        RecipeDTO GetRecipeById(int id);



        [OperationContract]
        string DeleteRecipe(int id);

        //

        [OperationContract]
        List<LikeDTO> GetLike();

        [OperationContract]
        string PostLike(LikeDTO likeDTO);


    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfSOAP.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
