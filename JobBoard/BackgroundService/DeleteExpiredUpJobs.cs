namespace JobBoard.BackgroundService
{
	public class DeleteExpiredUpJobs : IHostedService, IDisposable
	{
		private ILogger<DeleteExpiredUpJobs> _logger;

		public IServiceProvider Services { get; set; }

		private Timer _timer;

		public DeleteExpiredUpJobs(ILogger<DeleteExpiredUpJobs> logger, IServiceProvider services)
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
			Console.WriteLine($"{nameof(DeleteExpiredUpJobs)} is started");
			_timer = new Timer(DeleteJobs, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			Console.WriteLine($"{nameof(DeleteExpiredUpJobs)} is stoped");
	
			throw new NotImplementedException();
		}

		private void DeleteJobs(object state)
		{
			using IServiceScope scope = Services.CreateScope();

			var jobBoardContext = scope.ServiceProvider.GetRequiredService<JobBoardContext>();

			try
			{
				var jobs = jobBoardContext.Jobs.Where(j => j.ApplicationDeadline < DateTime.Now).ToList();


				foreach (var job in jobs)
				{
					var joobsekers = jobBoardContext.jobSeekers.Where(js => js.JobId == job.Id).ToList();
					 
					jobBoardContext.Jobs.Remove(job); 
					foreach (var jobSeeker in joobsekers)
					{
						jobBoardContext.jobSeekers.Remove(jobSeeker);
					}
					jobBoardContext.SaveChanges();
				}
			}
			catch (Exception e)
			{
				_logger.LogWarning($"Someting went wrong while {nameof(DeleteExpiredUpJobs)} working");

				throw e;
			}
		}


		



	}
}
