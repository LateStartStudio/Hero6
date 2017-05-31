#pragma once

#include <vector>

namespace latestartstudio {
	namespace search {
		namespace pathfinder {
			class Node {
			public:
				explicit Node(
					int id,
					bool isBlocked = false,
					bool isVisited = false,
					int h = 0,
					int g = 0,
					Node* parent = nullptr);

				const int ID;

				bool IsBlocked;
				bool IsVisited;
				int H;
				int G;
				Node* Parent;
				std::vector<Node*> Children;

				int GetF() const;

				bool operator==(const Node& node) const;
				bool operator!=(const Node& node) const;
			};
		}
	}
}
