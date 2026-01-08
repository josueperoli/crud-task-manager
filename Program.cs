using TaskManager.Services;

var taskService = new TaskService();

while (true)
{
    Console.Clear();
    Console.WriteLine("===== TASK MANAGER =====");
    Console.WriteLine("1 - Criar tarefa");
    Console.WriteLine("2 - Listar tarefas");
    Console.WriteLine("3 - Concluir tarefa");
    Console.WriteLine("4 - Remover tarefa");
    Console.WriteLine("0 - Sair");

    Console.Write("\nEscolha uma opção: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Título: ");
            var title = Console.ReadLine();

            Console.Write("Descrição: ");
            var description = Console.ReadLine();

            taskService.CreateTask(title!, description!);
            break;

        case "2":
            taskService.ListTasks();
            break;

        case "3":
            Console.Write("ID da tarefa: ");
            int completeId = int.Parse(Console.ReadLine()!);
            taskService.CompleteTask(completeId);
            break;

        case "4":
            Console.Write("ID da tarefa: ");
            int deleteId = int.Parse(Console.ReadLine()!);
            taskService.DeleteTask(deleteId);
            break;

        case "0":
            Console.WriteLine("Encerrando...");
            return;

        default:
            Console.WriteLine("❌ Opção inválida!");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}