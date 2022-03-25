# TableStyleContainer.ElementOrDefault Method (string, bool)
 

Returns the TableStyle with the specified name or <i>null</i> if the TableStyle cannot be found.

## Syntax

**C#**<br />
``` C#
public TableStyle ElementOrDefault(
	string name,
	bool openForWrite = false
)
```

**VB**<br />
``` VB
Public Function ElementOrDefault ( 
	name As String,
	Optional openForWrite As Boolean = false
) As TableStyle
```


#### Parameters
<dl><dt>name</dt><dd>Type: string<br />The name of the TableStyle.</dd><dt>openForWrite (Optional)</dt><dd>Type: bool<br />True, if the object should be opened for-write. By default the object is opened readonly.</dd></dl>

#### Return Value
Type: TableStyle<br />The TableStyle with the specified name.

## See Also


#### Reference
<a href="T_Linq2Acad_TableStyleContainer.md">TableStyleContainer Class</a><br /><a href="N_Linq2Acad.md">Linq2Acad Namespace</a><br />