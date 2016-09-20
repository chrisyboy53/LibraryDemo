using System.Collections.Generic;

namespace Homemade.DataAccess
{
    /// <summary>
    /// Common DataAccess for all DataAccess Objects
    /// </summary>
    public interface IDataAccess<T> {

        /// <summary>
        /// Gets the entire set of T
        /// </summary>
        /// <returns>List of T</returns>
        IList<T> GetList();

        /// <summary>
        /// Gets T by the identifier
        /// </summary>
        /// <param name="id">identifier to search for</param>
        /// <returns>Returns T if found otherwise null</returns>
        T GetById(int id);

        /// <summary>
        /// Updates T in the data source
        /// </summary>
        /// <param name="obj">Object to update</param>
        /// <returns>True or false if the update was successfull</returns>
        bool Update(T obj);

        /// <summary>
        /// Deletes T from the data source
        /// </summary>
        /// <param name="obj">Object to remove</param>
        /// <returns>True or false if the delete was successfull</returns>
        bool Delete(T obj);

        /// <summary>
        /// Inserts T obj to the data source
        /// </summary>
        /// <param name="obj">Object to insert</param>
        /// <returns>True or false if the insert was successfull</returns>
        bool Insert(T obj);

    }
}