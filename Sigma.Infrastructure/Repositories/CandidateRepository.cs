namespace Sigma.Infrastructure.Repositories;

using CsvHelper;
using CsvHelper.Configuration;

using Sigma.Domain.AggregateModels.CandidateAggregate;

using System.Globalization;

public class CandidateRepository : ICandidateRepository
{
    private readonly string _csvFilePath;

    public CandidateRepository(string csvFilePath)
    {
        _csvFilePath = csvFilePath;
    }

    public async Task<Candidate> GetCandidateByEmailAsync(string email)
    {
        var candidates = await ReadCandidatesFromFileAsync();
        return candidates.FirstOrDefault(c => c.Email == email);
    }

    public async Task AddCandidateAsync(Candidate candidate)
    {
        var candidates = await ReadCandidatesFromFileAsync();

        if (candidates.Any(c => c.Email == candidate.Email))
        {
            throw new InvalidOperationException("A candidate with this email already exists.");
        }

        candidates.Add(candidate);
        await WriteCandidatesToFileAsync(candidates);
    }

    public async Task UpdateCandidateAsync(Candidate candidate)
    {
        var candidates = await ReadCandidatesFromFileAsync();
        var index = candidates.FindIndex(c => c.Email == candidate.Email);

        if (index == -1)
        {
            throw new KeyNotFoundException("Candidate not found.");
        }

        candidates[index] = candidate;
        await WriteCandidatesToFileAsync(candidates);
    }

    private async Task<List<Candidate>> ReadCandidatesFromFileAsync()
    {
        if (!File.Exists(_csvFilePath))
        {
            return new List<Candidate>();
        }

        using var reader = new StreamReader(_csvFilePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        var records = csv.GetRecords<Candidate>().ToList();

        return await Task.FromResult(records);
    }

    private async Task WriteCandidatesToFileAsync(List<Candidate> candidates)
    {
        await using var writer = new StreamWriter(_csvFilePath);
        await using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
        await csv.WriteRecordsAsync(candidates);
    }
}