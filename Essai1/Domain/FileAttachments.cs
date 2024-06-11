using Microsoft.AspNetCore.Components.Forms;

namespace Essai1.Domain;

public class FileAttachments
{
    public IBrowserFile NewFile { get; set; }
    public IList<IBrowserFile> Files { get; set; }
}