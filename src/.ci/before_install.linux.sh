# git-lfs
mkdir -p $HOME/bin;
wget https://github.com/github/git-lfs/releases/download/v1.1.2/git-lfs-linux-amd64-1.1.2.tar.gz;
tar xvfz git-lfs-linux-amd64-1.1.2.tar.gz;
mv git-lfs-1.1.2/git-lfs $HOME/bin/git-lfs;
export PATH=$PATH:$HOME/bin/;

# MonoGame
wget http://www.monogame.net/releases/v3.4/MonoGame.Linux.zip;
unzip ./MonoGame.Linux.zip;

find * -type f -exec chmod 777 {} \;
