#pragma once

#include <vector>

#include "node.h"

namespace latestartstudio {
	namespace search {
		namespace pathfinder {
			class Pathfinder {
			protected:
				~Pathfinder() {}

			public:
				std::vector<Node> virtual FindPath(Node start, Node end) = 0;
			};
		}
	}
}
