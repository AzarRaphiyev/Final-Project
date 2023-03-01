namespace JobBoard.BackgroundService
{
	public class DeleteExpiredUpReklam : IHostedService, IDisposable
	{

		private ILogger<DeleteExpiredUpReklam> _logger;
		public IServiceProvider Services { get; set; }

		private Timer _timer;

		public DeleteExpiredUpReklam(ILogger<DeleteExpiredUpReklam> logger, IServiceProvider services)
		{
			_logger = logger;
			Services = services;

		}

		public void Dispose()
		{
			_timer.Dispose();
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			Console.WriteLine($"{nameof(DeleteExpiredUpReklam)} is started");
			_timer = new Timer(DeleteReklam, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

			return Task.CompletedTask;
		}
		public Task StopAsync(CancellationToken cancellationToken)
		{
			Console.WriteLine($"{nameof(DeleteExpiredUpReklam)} is stoped");

			throw new NotImplementedException();
		}
		private void DeleteReklam(object state)
		{
			using IServiceScope scope = Services.CreateScope();

			var jobBoardContext = scope.ServiceProvider.GetRequiredService<JobBoardContext>();

			try
			{
				var reklams = jobBoardContext.reklams.Where(r => r.DeadlineTime < DateTime.Now).ToList();


				foreach (var reklam in reklams)
				{
					jobBoardContext.reklams.Remove(reklam);


					jobBoardContext.SaveChanges();
				}
			}
			catch (Exception e)
			{
				_logger.LogWarning($"Someting went wrong while {nameof(DeleteExpiredUpReklam)} working");

				throw e;
			}
		}
	}
}
