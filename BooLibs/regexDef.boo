namespace BooLibs


import System

class regexDef:
"""Description of Class1."""
	comments = { """single_line_full""" : """/^\s*\/\//""",    """single_line_mixed """ : """/\/\//""", """multiline_begin""" : """/\/\*/""",
			"""multiline_end""" : """/\*\/\s*$/""", """multiline_begin_mixed""" : """/^[^\s]+.*\/\*/""",
			"""multiline_end_mixed""" : """/\*\/\s*[^\s]+$/""", """blank_line""" : """/^\s*$/""" } 
		

	public def constructor():
		pass
	public def isComment(line as string):
		if string in comments:
			return true;
		else:
			return false;
		
	public def getCSComments():
		return comments 
		
	public def extractBlockComments(fullCode as string) as string:
		commentStr = @/\/\*[^*]*\*+(?:[^*\/][^*]*\*+)*\//.Match(fullCode)as string
		return commentStr
		
	public def removeBlockComments(fullCode as string) as string:
		commentStr = @/\/\*[^*]*\*+(?:[^*\/][^*]*\*+)*\//.Replace(fullCode," ") as string
		commentStr = @/^p%/.Replace(commentStr,"") as string
		return commentStr
		


			
