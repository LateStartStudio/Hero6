/*
	SWIG interface
*/

%module search_native

%ignore operator==;
%ignore operator!=;

%nspace test;

%typemap(csclassmodifiers) latestartstudio::search::pathfinder::Node "public partial class"

%{
#include "node.h"
%}

%include "std_vector.i"
%include "node.h"

%template(NodeVector)std::vector<latestartstudio::search::pathfinder::Node*>;
