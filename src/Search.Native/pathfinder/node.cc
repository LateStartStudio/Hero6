#include "node.h"

namespace latestartstudio {
	namespace search {
		namespace pathfinder {
			Node::Node(
				int id,
				bool isBlocked,
				bool isVisited, int h,
				int g,
				Node* parent) :
				ID(id),
				IsBlocked(isBlocked),
				IsVisited(isVisited),
				H(h),
				G(g),
				Parent(parent) {
			}

			int Node::GetF() const {
				return this->H + this->G;
			}

			bool Node::operator==(const Node& node) const {
				return this->ID == node.ID;
			}

			bool Node::operator!=(const Node& node) const {
				return !(this->ID == node.ID);
			}
		}
	}
}
