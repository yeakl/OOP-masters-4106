using GenealogicalTree.APP.UI;
using GenealogicalTree.BLL.Contract;
using GenealogicalTree.BLL.Service;

namespace GenealogicalTree.APP.Commands;

public class CreatePerson(IPersonService service) : ICommand
{
    public void Execute()
    {
        var personDto = InputHandler.InputPerson();
        service.AddPerson(personDto);
    }
}