#include "astar.h"

namespace latestartstudio {
	namespace search {
		namespace pathfinder {
			std::vector<Node> AStar::FindPath(Node start, Node end)
			{
				start.Parent = nullptr;
				start.G = 0;
				start.H = 0;

				//this->open.push(start);

				//while (!this->open.empty()) {
				//	Node current = this->open.top();
				//	this->open.pop();
				//	current.IsVisited = true;
				//	this->closed.push_back(current);

				//	if (current == end) {
				//		// TODO Do more
				//		std::vector<Node> path;
				//		return path;
				//	}
				//}
				return {};
			}
		}
	}
}
