#pragma once

#include <vector>
#include <queue>

#include "node.h"
#include "pathfinder.h"

namespace latestartstudio {
	namespace search {
		namespace pathfinder {
			class AStar : public Pathfinder {
			public:
				virtual ~AStar() {}

				std::vector<Node> FindPath(Node start, Node end) override;

			private:
				std::priority_queue<Node> open;
				std::vector<Node> closed;
			};
		}
	}
}
