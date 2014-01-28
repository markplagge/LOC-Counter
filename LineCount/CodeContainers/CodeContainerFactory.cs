using System;
using System.Collections.Generic;
using System.Text;

namespace LineCount.CodeContainers
{
    /// <summary>
    /// Simple factory idiom for creating the appropriate code container based
    /// on the path entered in the application
    /// </summary>
    class CodeContainerFactory
    {
        public CodeContainer CreateCodeContainer(string fullName)
        {
            CodeContainer result = null;
            if (Solution.CheckValidExtension(fullName))
                result = new Solution(fullName);
            else if (Project.CheckValidExtension(fullName))
                result = new Project(fullName);
            else if (CodeFile.CheckValidExtension(fullName))
                result = new CodeFile(fullName);
            return result;
        }
    }
}
