using System.Collections.Generic;

namespace ModelEntities
{
    public class Techno
    {
        /* membres de classe propres à l'objet */
        private int _technoID;
        public string Name { get; set; }

        /* membres de classe liés à la cardinalité des objets */
        // Une techno peut avoir plusieurs questions
        public List<Question> LinkedQuestions { get; set; } = new List<Question>();

        public Techno(string pName)
        {
            Name = pName;
        }

        public Techno(string pName, List<Question> pQuestions) : this(pName)
        {
            LinkedQuestions = pQuestions;
        }
    }
}
