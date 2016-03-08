﻿namespace DevSpace.Common {
	public interface ISponsor {
		int Id { get; }
		ISponsorLevel Level { get; }
		string DisplayName { get; }
		string LogoLarge { get; }
		string LogoSmall { get; }
	}
}
