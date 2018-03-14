/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les types de question possibles
/// </summary>

using System.Collections.Generic;

namespace ModelEntities
{
    class QuestionType
    {
        #region Properties
        public int QTypeID { get; set; }
        public string Wording { get; set; }
        #endregion

        #region Associations
        // Un type de question a plusieurs questions
        public virtual ICollection<Question> LinkedQuestions { get; set; }
        #endregion
    }
}
