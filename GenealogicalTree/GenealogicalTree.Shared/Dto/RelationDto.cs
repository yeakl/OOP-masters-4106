using GenealogicalTree.Shared.Enum;

namespace GenealogicalTree.Shared.Dto;

public class RelationDto(int subject, int relation, RelationType relationType)
{
    public int SubjectId { get; } = subject;
    public int RelationId { get; } = relation;
    public RelationType RelationType { get; } = relationType;
}