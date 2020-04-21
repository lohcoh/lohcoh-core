Is it possible to do this?...
    <EditForm LkGenerate Model="@customer" OnValidSubmit="HandleValidSubmit"/></lk>
instead of this...
    <lk><EditForm Model="@customer" OnValidSubmit="HandleValidSubmit"/></lk>
 
 short answer: No.
It might be possible to add lowkode to an application at startup.
That is, lowkode would be added at startup and no &lt;lk&gt; elements would be needed in templates.
