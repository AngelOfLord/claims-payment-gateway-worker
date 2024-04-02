namespace claims_payment_gateway_worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    IEnumerable<(int Id, int Number)> _sut = [(1, 1), (1, 2), (1, 3), (2, 1), (2, 2)];

                    var groups = _sut.ToLookup(x => x.Id);
                    foreach (var group in groups)
                    {
                        _logger.LogInformation("Key : {key} & Values : {values}", group.Key, groups[3]);

                    }

                    
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
